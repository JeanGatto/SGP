using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SGP.PublicApi.Filters;
using SGP.PublicApi.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Throw;

namespace SGP.PublicApi.Extensions
{
    internal static class SwaggerExtensions
    {
        internal static IServiceCollection AddOpenApi(this IServiceCollection services)
            => services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                .AddSwaggerGen(options =>
                {
                    options.OperationFilter<SwaggerDefaultValuesFilter>();

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description =
                            "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                            "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                            "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            Array.Empty<string>()
                        }
                    });

                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath, true);
                })
                .AddSwaggerGenNewtonsoftSupport();

        internal static IApplicationBuilder UseOpenApi(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            provider.ThrowIfNull();

            app.UseSwagger().UseSwaggerUI(options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var groupName in provider.ApiVersionDescriptions.Select(description => description.GroupName))
                    options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());
            });

            return app;
        }
    }
}