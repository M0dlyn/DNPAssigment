// ICommentRepository.cs
using Entities;

namespace RepositoryContracts
{
    public interface ICommentRepository
    {
        Task<Comment> AddAsync(Comment comment);
        Task<Comment> GetSingleAsync(int id);
        Task DeleteAsync(int id);
        Task<List<Comment>> GetAllAsync();
        Task UpdateAsync(Comment comment);
        IQueryable<Comment> GetMany();
    }
}