using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class UserInMemoryRepository : IUserRepository
{
    private List<User> users = new List<User>();

    public UserInMemoryRepository()
    {
        _ = AddAsync(new User()).Result;
        _ = AddAsync(new User()).Result;
        _ = AddAsync(new User()).Result;
        _ = AddAsync(new User()).Result;
    }

    public Task<User> AddAsync(User user)
    {
        user.Id = Guid.NewGuid();
        users.Add(user);
        return Task.FromResult(user);
    }

    public Task<User> GetSingleAsync(Guid id)
    {
        User? user = users.SingleOrDefault(u => u.Id == id);
        if (user is null)
        {
            throw new InvalidOperationException($"User with Id '{id}' does not exist");
        }
        return Task.FromResult(user);
    }

    public Task DeleteAsync(Guid id)
    {
        User? userToRemove = users.SingleOrDefault(u => u.Id == id);
        if (userToRemove is null)
        {
            throw new InvalidOperationException($"User with Id '{id}' does not exist");
        }
        users.Remove(userToRemove);
        return Task.CompletedTask;
    }

    public Task<List<User>> GetAllAsync()
    {
        return Task.FromResult(users.ToList());
    }

    public Task UpdateAsync(Guid id, User user)
    {
        User? existingUser = users.SingleOrDefault(u => u.Id == user.Id);
        if (existingUser == null)
        {
            throw new InvalidOperationException($"User with Id '{user.Id}' does not exist");
        }
        users.Remove(existingUser);
        users.Add(user);
        return Task.CompletedTask;
    }

    public IQueryable<User> GetMany()
    {
        return users.AsQueryable();
    }

    public Task<User> FindByUsernameAsync(string requestUsername)
    {
        User? user = users.SingleOrDefault(u => u.Name == requestUsername);
        return Task.FromResult(user);
    }
}