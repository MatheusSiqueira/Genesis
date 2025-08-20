using Microsoft.Extensions.DependencyInjection;

namespace Genesis.API.Extensions
{
    public static class CorsConfiguration
    {
        public const string PolicyName = "AllowFront";

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, policy =>
                {
                    policy
                        .WithOrigins(
                            "http://localhost:5173",        // DEV (Vite)
                            "https://lab-genesis.online",   // PROD (Front)
                            "https://www.lab-genesis.online"// (se usar www)
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    // .AllowCredentials(); // só se usar COOKIE; com JWT no header, deixe SEM
                });
            });

            return services;
        }
    }
}