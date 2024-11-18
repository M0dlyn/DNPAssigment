using ApiContracts;
using Microsoft.AspNetCore.Mvc;
using ServicesContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto request)
    {
        try
        {
            AuthResponseDto response = await authService.LoginAsync(request);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Unauthorized(e.Message);
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterDto request)
    {
        try
        {
            AuthResponseDto response = await authService.RegisterAsync(request);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}