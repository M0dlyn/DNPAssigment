using System.Text.Json;
using ApiContracts;
using Entities;

using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services;

public class HttpUserService : IUserService
{

    
    
    private readonly HttpClient client;
    private readonly EfcRepositories.AppContext context;

    public HttpUserService(HttpClient client, EfcRepositories.AppContext context)
    {
        this.client = client;
        this.context = context;
    }
    
    public async Task<UserDto> AddUserAsync(CreateUserDto request)
    {
        var user = new User
        {
            Name = request.Name,
            Password = request.Password
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password
        };
    }

    public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto request)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        user.Name = request.Name;
        user.Password = request.Password;

        context.Users.Update(user);
        await context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password
        };
    }

   
    public async Task<UserDto> DeleteUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password
        };
    }
    

  
    public async Task<UserDto> GetUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password
        };
    }
 

    
    public async Task<List<UserDto>> GetUsersAsync()
    {
        var users = await context.Users.ToListAsync();
        return users.Select(user => new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password
        }).ToList();
    }
    
    
  
}