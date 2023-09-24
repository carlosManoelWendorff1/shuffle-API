using Shuffle.Data;
using Shuffle.Models;
using Shuffle.Models.Common;
using Shuffle.Services.Interfaces;

namespace Shuffle.Services;

public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
{
    private readonly ShuffleDbContext _context;

    protected BaseService(ShuffleDbContext context)
    {
        _context = context;
    }
    
    public async Task<TEntity> FindById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> FindAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> Create(TEntity request)
    {
        await _context.Set<TEntity>().AddAsync(request);
        await _context.SaveChangesAsync();
        return await _context.Set<TEntity>().ToListAsync();
    }
    
    public async Task<IEnumerable<TEntity>>? Update(TEntity request)
    {
        var existingPost = await _context.Posts.FindAsync(request.Id);

        if (existingPost is null) 
            return null;

        _context.Set<TEntity>().Update(request);
        await _context.SaveChangesAsync();
        
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>>? Delete(Guid id)
    {
        var existingEntity = await _context.Set<TEntity>().FindAsync(id);

        if (existingEntity is null) 
            return null;

        _context.Set<TEntity>().Remove(existingEntity);
        await _context.SaveChangesAsync();
        
        return await _context.Set<TEntity>().ToListAsync();
    }
}