using HubScribe.Domain.Articles.Repositories.Read;
using HubScribe.Domain.Articles.Repositories.Write;
using HubScribe.Infrastructure.Repositories.Read;
using HubScribe.Infrastructure.Repositories.Write;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace HubScribe.Infrastructure.Extensions;

public static class ServiceRegistrationExtension
{
    public static void ConfigureInfrastructureLayer(this IServiceCollection services)
    {
        // TODO: Read Connection string from app settings [ ]
        #region [ Database Connection ]
        services.AddSingleton<IMongoClient, MongoClient>(configuration =>
        {
            var connectionString = MongoClientSettings.FromConnectionString("");
            return new MongoClient();
        });

        services.AddScoped(services =>
        {
            var client = services.GetRequiredService<IMongoClient>();
            return client.GetDatabase("");
        });
        #endregion

        #region [ Repositories ]
        services.AddScoped<IArticleReadRepository, ArticleReadRepository>();
        services.AddScoped<IArticleWriteRepository, ArticleWriteRepository>();
        #endregion
    }
}