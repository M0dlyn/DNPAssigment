using Entities;

namespace RepositoryContracts;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task UpdateAsync(int id, User user);
    Task DeleteAsync(int id);
    Task<User> GetSingleAsync(int Id);
    IQueryable<User> GetMany();
}