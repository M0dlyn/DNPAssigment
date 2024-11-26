using ApiContracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository userRepo;

    public UsersController(IUserRepository userRepo)
    {
        this.userRepo = userRepo;
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto request)
    {
        try
        {
            User user = new User { Name = request.Name,  Password = request.Password };
            User created = await userRepo.AddAsync(user);
            UserDto userDto = new(created.Id, created.Name, created.Password);
            return Created($"/Users/{created.Id}", userDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetSingleUser([FromRoute] int id)
    {
        try
        {
            User result = await userRepo.GetSingleAsync(id);
            UserDto userDto = new(result.Id, result.Name, result.Password);
            return Ok(userDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] int id)
    {
        try
        {
            await userRepo.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        List<User> users = await userRepo.GetAllAsync();
        List<UserDto> result = users.Select(user => new UserDto(user.Id, user.Name, user.Password)).ToList();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser([FromRoute] int id, [FromBody] UpdateUserDto request)
    {
        try
        {
            User user = await userRepo.GetSingleAsync(id);
            user.Name = request.Name;
            user.Id = request.Id;
            await userRepo.UpdateAsync(id ,user);
            UserDto userDto = new(user.Id, user.Name, user.Password);
            return Ok(userDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}