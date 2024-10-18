namespace HubScribe.Domain.Articles.Entities;

public class Like
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public string UserId { get; set; }
    public DateTime LikedDate { get; set; }
}