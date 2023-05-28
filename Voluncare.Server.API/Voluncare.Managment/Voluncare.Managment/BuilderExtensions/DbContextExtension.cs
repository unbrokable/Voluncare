using Microsoft.EntityFrameworkCore;
using Voluncare.EntityFramework.Context;

namespace Voluncare.Managment.BuilderExtensions
{
    internal static class DbContextExtension
    {
        internal static IServiceCollection AddDbContextExtensions(this IServiceCollection services, WebApplicationBuilder buelder)
        {
            services.AddDbContext<VoluncareDbContext>(
                o => o.UseNpgsql(buelder.Configuration.GetConnectionString("VoluncareTest"))
                );

            return services;
        }
    }
}
