using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shuffle.Models;
using Shuffle.Services.Interfaces;

namespace Shuffle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(
        ILogger<UserController> logger,
        IUserService userService
    )
    {
        _logger = logger;
        _userService = userService;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var result = await _userService.FindAll();
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {
        var result = await _userService.FindById(id); 
        
        if (result is null)
            return NotFound("Sorry, but this user doesn't exist.");
        
        return Ok(result);
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<List<User>>> AddUser(string username, string password, string email)
    {
        var result = await _userService.Create(new User(username, email, password, "user"));
        return Ok(result);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<List<User>>> UpdateUser([FromBody] User request)
    {
        var result = await _userService.Update(request);
        
        if (result is null)
            return NotFound("Sorry, but this user doesn't exist.");
        
        return Ok(result);
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<List<User>>> DeleteUser(Guid id)
    {
        var result = await _userService.Delete(id);
        
        if (result is null)
            return NotFound("Sorry, but this user doesn't exist.");
        
        return Ok(result);
    }
}