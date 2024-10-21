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
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserDto>> DeleteUser([FromRoute]int id)
    {
           
            await userRepo.DeleteAsync(id);
            return NoContent();       
       
    }

    [HttpGet]
    public async Task<ActionResult<IQueryable<UserDto>>> GetUsers()
    {
        IQueryable<User> users = userRepo.GetMany();
        List<UserDto> userDtos = users.Select(user => new UserDto(user.Id, user.Username)).ToList();
        return Ok(userDtos);
    }
    
    
    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser([FromRoute]int id, [FromBody]UpdateUserDto request)
    {
        try
        {
            User user = await userRepo.GetSingleAsync(id);
            user.Username = request.Username;
            user.Password = request.Password;
            await userRepo.UpdateAsync(id,user);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    
    
}