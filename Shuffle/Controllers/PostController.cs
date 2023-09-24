using Microsoft.AspNetCore.Mvc;
using Shuffle.Models;
using Shuffle.Services.Interfaces;

namespace Shuffle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly IPostService _postService;
    
    public PostController(
        ILogger<PostController> logger, 
        IPostService postService
    )
    {
        _logger = logger;
        _postService = postService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetAllPosts()
    {
        var result = await _postService.FindAll();
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Post>> GetPostById(Guid id)
    {
        var result = await _postService.FindById(id); 
        
        if (result is null)
            return NotFound("Sorry, but this post doesn't exist.");
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Post>>> AddPost([FromBody] Post request)
    {
        var result = await _postService.Create(request);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Post>>> UpdatePost([FromBody] Post request)
    {
        var result = await _postService.Update(request);
        
        if (result is null)
            return NotFound("Sorry, but this post doesn't exist.");
        
        return Ok(result);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<List<Post>>> DeletePost(Guid id)
    {
        var result = await _postService.Delete(id);
        
        if (result is null)
            return NotFound("Sorry, but this post doesn't exist.");
        
        return Ok(result);
    }
}