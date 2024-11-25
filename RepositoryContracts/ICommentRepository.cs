// ICommentRepository.cs
using Entities;

namespace RepositoryContracts
{
    public interface ICommentRepository
    {
        Task<Comment> AddAsync(Comment comment);
        Task<Comment> GetSingleAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<List<Comment>> GetAllAsync();
        Task UpdateAsync(Comment comment);
        IQueryable<Comment> GetMany();
    }
}