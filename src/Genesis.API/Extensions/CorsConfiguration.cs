using Microsoft.Extensions.DependencyInjection;
using System;

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
                            "https://lab-genesis.online",   // PROD (front)
                            "https://www.lab-genesis.online"// se usar www
                        )
                        .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE", "OPTIONS")
                        .WithHeaders("Content-Type", "Authorization", "X-Requested-With")
                        .SetPreflightMaxAge(TimeSpan.FromHours(1))
                        // .AllowCredentials(); // só se autenticar por COOKIE; com JWT via header, deixe sem
                        ;
                });
            });

            return services;
        }
    }
} 