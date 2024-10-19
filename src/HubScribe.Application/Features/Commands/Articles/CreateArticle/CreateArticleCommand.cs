using MediatR;

namespace HubScribe.Application.Features.Commands.Articles.CreateArticle;

public class CreateArticleCommand : IRequest<Guid>
{
    public string AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public List<Guid> TagIds { get; set; }
}