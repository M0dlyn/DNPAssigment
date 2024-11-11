using ApiContracts;

namespace BlazorApp.Services;

public class HttpUserService : IUserService
{

    private readonly HttpClient client;
    
    public HttpUserService(HttpClient client)
    {
        this.client = client;
    }
    
    public Task<UserDto> AddUserAsync(CreateUserDto request)
    {
     
    }

    public Task UpdateUserAsync(UpdateUserDto request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDto>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}