using System.Collections;
using Entities;

namespace RepositoryContracts
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetSingleAsync(int id);
        Task DeleteAsync(int id);
        Task<List<User>> GetAllAsync();
        Task UpdateAsync(int id, User user);
        IQueryable<User> GetMany();    }
}