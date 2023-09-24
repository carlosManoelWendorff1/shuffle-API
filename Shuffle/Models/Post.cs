using Shuffle.Models.Common;

namespace Shuffle.Models;

public class Post : AuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Guid PersonId { get; set; }
}