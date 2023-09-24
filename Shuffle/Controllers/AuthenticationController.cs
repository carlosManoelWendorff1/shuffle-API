using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shuffle.Models;
using Shuffle.Services;
using Shuffle.Services.Interfaces;

namespace Shuffle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IUserService _userService;

    public AuthenticationController(
        ILogger<AuthenticationController> logger,
        IUserService userService
    )
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate(string username, string password)
    {
        var user = await _userService.Find(username, password);

        if (user is null)
            return NotFound(new { message = "Username or password is incorrect" });

        var token = TokenService.GenerateToken(user);

        user.Password = string.Empty;

        return new
        {
            User = user,
            Token = token
        };
    }
}