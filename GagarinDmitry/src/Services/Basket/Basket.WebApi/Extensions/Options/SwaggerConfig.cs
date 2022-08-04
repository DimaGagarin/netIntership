using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Basket.WebApi.Extensions.Options
{
    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    public class SwaggerConfig : IConfigureOptions<SwaggerGenOptions>
    {
        /// <inheritdoc/>
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Description = "UI to use api without client",
                Title = "Basket",
            });

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri("http://host.docker.internal:10000/connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            { "Basket", "Basket" }
                        }
                    }
                }
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });

            options.CustomSchemaIds(x => x.FullName);
        }
    }
}
