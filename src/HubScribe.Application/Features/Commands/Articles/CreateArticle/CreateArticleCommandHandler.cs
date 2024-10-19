using HubScribe.Application.Services.Contracts;
using HubScribe.Domain.Articles.Entities;
using HubScribe.Domain.Articles.Enums;
using MediatR;

namespace HubScribe.Application.Features.Commands.Articles.CreateArticle;

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
{
    #region [ Fields ]
    private readonly IArticleService _articleService;
    #endregion

    #region [ Constructor ]
    public CreateArticleCommandHandler(IArticleService articleService)
    {
        _articleService = articleService;
    }
    #endregion

    #region [ Handler ] 
    public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = GenerateArticleModel(request);
        return await _articleService.AddArticleAsync(article, cancellationToken);
    }
    #endregion

    #region [ Private ]
    private static Article GenerateArticleModel(CreateArticleCommand request)
    {
        return new Article
        {
            Id = Guid.NewGuid(),
            AuthorId = request.AuthorId,
            Title = request.Title,
            Content = request.Content,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            Status = ArticleStatus.ReadyToPublish,
            IsDeleted = false,
            TagIds = request.TagIds
        };
    }
    #endregion
}