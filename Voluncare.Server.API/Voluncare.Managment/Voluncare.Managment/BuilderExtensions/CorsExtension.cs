namespace Voluncare.Managment.BuilderExtensions
{
    public static class CorsExtension
    {
        internal static IServiceCollection AddCorsExtension(this IServiceCollection services, WebApplicationBuilder buelder)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
