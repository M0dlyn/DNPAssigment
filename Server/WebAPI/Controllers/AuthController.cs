using ApiContracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository userRepo;

    public AuthController(IUserRepository userRepo)
    {
        this.userRepo = userRepo;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto request)
    {
        User user = await userRepo.FindByUsernameAsync(request.Username);
        if (user == null || user.Password != request.Password)
        {
            return Unauthorized("Invalid username or password.");
        }

        UserDto userDto = new UserDto(user.Id, user.Username);
        return Ok(userDto);
    }
}