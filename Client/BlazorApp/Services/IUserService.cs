using ApiContracts;

namespace BlazorApp.Services;

public interface IUserService
{
    public Task<UserDto> AddUserAsync(CreateUserDto request);
    public Task UpdateUserAsync(UpdateUserDto request);
    public Task DeleteUserAsync(Guid id);
    public Task<UserDto> GetUserAsync(Guid id);
    public Task<List<UserDto>> GetUsersAsync();
}