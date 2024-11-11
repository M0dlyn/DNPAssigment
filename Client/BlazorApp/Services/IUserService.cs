using ApiContracts;

namespace BlazorApp.Services;

public interface IUserService
{
    public Task<UserDto> AddUserAsync(CreateUserDto request);
    public Task<UserDto> UpdateUserAsync(int it, UpdateUserDto request);
    public Task<UserDto> DeleteUserAsync(int id);
    public Task<UserDto> GetUserAsync(int id);
    public Task<List<UserDto>> GetUsersAsync();
}