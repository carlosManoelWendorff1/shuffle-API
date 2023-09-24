using Shuffle.Models;

namespace Shuffle.Services.Interfaces;

public interface IPostService 
{
    Task<Post> FindById(Guid id);
    Task<IEnumerable<Post>> FindAll();
    Task<IEnumerable<Post>> Create(Post request);
    Task<IEnumerable<Post>>? Update(Post request);
    Task<IEnumerable<Post>>? Delete(Guid id);
}