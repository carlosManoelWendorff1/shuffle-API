using Shuffle.Models.Common;

namespace Shuffle.Models;

public class Post : AuditableEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public Post() { }
    
    public Post(string title, string content, Guid userId)
    {
        Title = title;
        Content = content;
        UserId = userId;
    }
}