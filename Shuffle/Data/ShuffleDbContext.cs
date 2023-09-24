global using Microsoft.EntityFrameworkCore;
using Shuffle.Models;

namespace Shuffle.Data;

public class ShuffleDbContext : DbContext
{
    public ShuffleDbContext(DbContextOptions<ShuffleDbContext> options) : base(options) { }
    
    public DbSet<Post> Posts { get; set; }
}