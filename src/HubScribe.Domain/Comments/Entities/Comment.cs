namespace HubScribe.Domain.Comments.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public string AuthorId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsApproved { get; set; }
    public bool IsDeleted { get; set; }
}