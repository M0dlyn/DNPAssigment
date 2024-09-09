using System.Formats.Tar;
using Entities;
using RepositoryContracts;


namespace InMemoryRepositories;

public class UserInMemoryRepository : IUserRepository
{
    private List<User> users = new List<User>();

    public Task<User> AddAsync(User user)
    {

        user.Id = users.Any()
            ? users.Max(user  => user.Id) + 1
            : 1;
        users.Add(user);
        return Task.FromResult(user);
        
    }

    public Task UpdateAsync(User user)
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

    public Task DeleteAsync(int id)
    {
        User? userToRemove = users.SingleOrDefault(u => u.Id == id);
        if (userToRemove is null)
        {
            throw new InvalidOperationException($"User with Id '{id}' does not exist");
        }
        
        users.Remove(userToRemove);
        return Task.CompletedTask;
    }

    public Task<User> GetSingleAsync(int Id)
    {
        User? user = users.SingleOrDefault(u => u.Id == Id);

        if (user is null)
        {
            throw new InvalidOperationException($"User with Id '{Id}' does not exist");
        }
        
        return Task.FromResult(user);
    }

    public IQueryable<User> GetMany()
    {
        return users.AsQueryable();
    }
}
