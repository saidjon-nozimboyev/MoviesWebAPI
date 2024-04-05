using Microsoft.OpenApi.Models;

namespace MoviesWebAPI.Configurations;

public static class SwaggerConfiguration
{
    public static void ConfigureSwaggerAuthorize(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSwaggerGen(x =>
        {
            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {

                Name = "Authorization",
                Description = "JWT Authorization header using the Bearer sheme. " +
                "Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }
}
