using HubScribe.Domain.Articles.Entities;

namespace HubScribe.Application.Services.Contracts;

public interface IArticleService
{
    Task<Guid> AddArticleAsync(Article article, CancellationToken cancellationToken);
}