using System.Collections;
using Entities;

namespace RepositoryContracts
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetSingleAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task UpdateAsync(Guid id, User user);
        IQueryable<User> GetMany();    }
}