using HubScribe.Domain.Articles.Enums;
using HubScribe.Domain.Comments.Entities;

namespace HubScribe.Domain.Articles.Entities;

public class Article
{
    public Guid Id { get; set; }
    public string AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int LikesCount { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime? PublishedDate { get; set; }
    public ArticleStatus Status { get; set; }

    public List<Comment> Comments { get; set; } = [];
    public List<Tag> Tags { get; set; } = [];
}