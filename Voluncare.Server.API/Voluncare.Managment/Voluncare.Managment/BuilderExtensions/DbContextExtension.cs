using Voluncare.EntityFramework.Context;

namespace Voluncare.Managment.BuilderExtensions
{
    internal static class DbContextExtension
    {
        internal static IServiceCollection AddDbContextExtensions(this IServiceCollection services)
        {
            services.AddDbContext<VoluncareDbContext>();

            return services;
        }
    }
}
