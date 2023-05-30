namespace Voluncare.Managment.BuilderExtensions
{
    public static class CookieConfigurationExtension
    {
        internal static IServiceCollection AddCookieConfigurationExtension(this IServiceCollection services, WebApplicationBuilder buelder)
        {
            services.ConfigureExternalCookie(options =>
            {
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = false;
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            return services;
        }
    }
}
