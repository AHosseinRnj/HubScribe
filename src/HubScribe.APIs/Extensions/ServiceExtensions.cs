using Asp.Versioning;

namespace HubScribe.APIs.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        var apiVersioningBuilder = services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
        });

        apiVersioningBuilder.AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}