using Shuffle.Data;
using Shuffle.Models;
using Shuffle.Services.Interfaces;

namespace Shuffle.Services;

public class UserService : BaseService<User>, IUserService
{
    private readonly ShuffleDbContext _context;
    
    public UserService(ShuffleDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> Find(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        return user;
    }
}