using Shuffle.Data;
using Shuffle.Models;
using Shuffle.Services.Interfaces;

namespace Shuffle.Services;

public class PostService : BaseService<Post>, IPostService
{
    public PostService(ShuffleDbContext context) : base(context) { }
}