using Shuffle.Models.Common;

namespace Shuffle.Models;

public class User : AuditableEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public virtual ICollection<Post> Posts { get; set; }

    public User() { }
    
    public User(string username, string email, string password, string role = "User")
    {
        Username = username;
        Email = email;
        Password = password;
        Role = role;
    }
}