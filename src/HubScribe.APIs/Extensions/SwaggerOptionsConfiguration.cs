using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HubScribe.APIs.Extensions;

/// <summary>
/// https://medium.com/@seldah/managing-multiple-versions-of-your-api-with-net-and-swagger-47b4143e8bf5
/// </summary>
public class SwaggerOptionsConfiguration : IConfigureNamedOptions<SwaggerGenOptions>
{
    #region [ Fields ]
    private readonly IApiVersionDescriptionProvider _provider;
    #endregion

    #region [ Constructor ]
    public SwaggerOptionsConfiguration(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }
    #endregion

    #region [ Methods ]
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                CreateVersionInfo(description));
        }
    }

    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }
    #endregion

    #region [ Private ]
    private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
    {
        var version = description.ApiVersion.ToString();

        var info = new OpenApiInfo()
        {
            Version = version,
            Title = $"HubScribe.APIs {version}",
        };

        if (description.IsDeprecated)
        {
            info.Description += "This API version has been deprecated.";
        }

        return info;
    }
    #endregion
}