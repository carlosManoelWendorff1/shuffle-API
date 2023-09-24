using Shuffle.Models;

namespace Shuffle.Services.Interfaces;

public interface IUserService : IBaseService<User>
{
    Task<User> Find(string username, string password);
}