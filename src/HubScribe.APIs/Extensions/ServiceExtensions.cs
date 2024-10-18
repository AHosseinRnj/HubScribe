using Asp.Versioning;
using Asp.Versioning.ApiExplorer;

namespace HubScribe.APIs.Extensions;

public static class ServiceExtensions
{
    #region [ API Versioning ]
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        var apiVersioningBuilder = services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
        });

        apiVersioningBuilder.AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VV";
            options.SubstitutionFormat = "VV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
    #endregion

    #region [ Swagger ]
    public static void ConfigureVersionedSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.ConfigureOptions<SwaggerOptionsConfiguration>();
    }

    public static void UseSwaggerWithVersioning(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            var apiVersionDescriptionProvider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                                            description.GroupName.ToUpperInvariant());
                }
            });
        }
    }
    #endregion
}