using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using Voluncare.Core.Interfaces;
using Voluncare.Infrastructure.UnitOfWork;
using Voluncare.Managment.BuilderExtensions;
using Voluncare.Managment.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContextExtension(builder);
// AutoMapper
builder.Services.AddAutoMapper(typeof(UserViewModelProfile));
// CORS
builder.Services.AddCorsExtension(builder);
// Cookie
builder.Services.AddCookieConfigurationExtension(builder);
// Identity
builder.Services.AddIdentityExtension(builder);
// Authentication JWT
builder.Services.AddAuthenticationExtension(builder);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Todo: for testing  
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
