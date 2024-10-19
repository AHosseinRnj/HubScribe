using FluentValidation;
using HubScribe.Application.Services.Contracts;
using HubScribe.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HubScribe.Application.Extensions;

public static class ServiceRegistrationExtension
{
    public static void ConfigureApplicationLayer(this IServiceCollection services)
    {
        #region [ MediatR ]
        var executingAssembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(executingAssembly); 
        });

        services.AddValidatorsFromAssembly(executingAssembly);
        #endregion

        #region [ Services ]
        services.AddScoped<IArticleService, ArticleService>();
        #endregion
    }
}