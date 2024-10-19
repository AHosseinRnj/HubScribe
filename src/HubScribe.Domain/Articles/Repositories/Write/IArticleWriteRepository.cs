using HubScribe.Domain.Articles.Entities;

namespace HubScribe.Domain.Articles.Repositories.Write;

public interface IArticleWriteRepository
{
    Task<Guid> CreateArticleAsync(Article article, CancellationToken cancellationToken);
}