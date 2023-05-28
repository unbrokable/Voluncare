using Microsoft.AspNetCore.Identity;
using Voluncare.Core.Entities;
using Voluncare.EntityFramework.Context;

namespace Voluncare.Managment.BuilderExtensions
{
    public static class IdentityExtension
    {
        internal static IServiceCollection AddIdentityExtension(this IServiceCollection services, WebApplicationBuilder buelder)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>> (options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<VoluncareDbContext>();

            return services;
        }
    }
}
