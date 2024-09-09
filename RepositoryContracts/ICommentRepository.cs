using Entities;

namespace RepositoryContracts;

public interface ICommentRepository
{
    Task<Comment> AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(int id);
    Task<Comment> GetSingleAsync(int id);
    IQueryable<Comment> GetMany();
    Task<Comment> LikeAsync(Comment comment);
    Task<Comment> DislikeAsync(Comment comment);
    Task<Comment> CommentAsync(Comment comment);
}