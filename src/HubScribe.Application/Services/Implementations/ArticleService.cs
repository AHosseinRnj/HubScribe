using HubScribe.Application.Services.Contracts;
using HubScribe.Domain.Articles.Entities;
using HubScribe.Domain.Articles.Repositories.Write;

namespace HubScribe.Application.Services.Implementations;

public class ArticleService : IArticleService
{
    #region [ Fields ]
    private readonly IArticleWriteRepository _articleWriteRepository;
    #endregion

    #region [ Constructor ]
    public ArticleService(IArticleWriteRepository articleWriteRepository)
    {
        _articleWriteRepository = articleWriteRepository;
    }
    #endregion

    #region [ Methods ]
    public async Task<Guid> AddArticleAsync(Article article, CancellationToken cancellationToken)
    {
        // TODO: Validate if tagIds are valid [ ]

        return await _articleWriteRepository.CreateArticleAsync(article, cancellationToken);
    }
    #endregion
}