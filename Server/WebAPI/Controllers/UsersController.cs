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
            User user = new(request.Username, request.Password);
            User created = await userRepo.AddAsync(user);
            UserDto userDto = new(created.Id, created.Username);
            return Created($"/Users/{userDto.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }

    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetSingleUser([FromRoute]int id)
    {
        try
        {
            User result =  await userRepo.GetSingleAsync(id);
            UserDto userDto = new(result.Id, result.Username);
            return Ok(userDto); 
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
    }
    
    []
    
}