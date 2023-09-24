using Shuffle.Data;
using Shuffle.Models;
using Shuffle.Services.Interfaces;

namespace Shuffle.Services;

public class PostService : IPostService
{
    private readonly ShuffleDbContext _context;
    
    public PostService(ShuffleDbContext context)
    {
        _context = context;
    }
    
    public async Task<Post> FindById(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);
        return post;
    }

    public async Task<IEnumerable<Post>> FindAll()
    {
        var posts = await _context.Posts.ToListAsync();
        return posts;
    }

    public async Task<IEnumerable<Post>> Create(Post request)
    {
        request.Id = Guid.NewGuid();
        await _context.Posts.AddAsync(request);
        await _context.SaveChangesAsync();
        return await _context.Posts.ToListAsync();
    }
    
    public async Task<IEnumerable<Post>>? Update(Post request)
    {
        var existingPost = await _context.Posts.FindAsync(request.Id);

        if (existingPost is null) 
            return null;

        existingPost.Title = request.Title;
        existingPost.Content = request.Content;
        existingPost.LastModified = DateTimeOffset.Now;
        
        await _context.SaveChangesAsync();
        return await _context.Posts.ToListAsync();
    }

    public async Task<IEnumerable<Post>>? Delete(Guid id)
    {
        var existingPost = await _context.Posts.FindAsync(id);

        if (existingPost is null) 
            return null;

        _context.Posts.Remove(existingPost);
        await _context.SaveChangesAsync();
        
        return await _context.Posts.ToListAsync();
    }
}