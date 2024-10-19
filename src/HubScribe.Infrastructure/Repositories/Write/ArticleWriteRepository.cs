using HubScribe.Domain.Articles.Entities;
using HubScribe.Domain.Articles.Repositories.Write;

namespace HubScribe.Infrastructure.Repositories.Write;

public class ArticleWriteRepository : IArticleWriteRepository
{
    #region [ Fields ]

    #endregion

    #region [ Constructor ]
    public ArticleWriteRepository()
    {
        
    }
    #endregion

    #region [ Methods ]
    public Task<Guid> CreateArticleAsync(Article article, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    #endregion
}