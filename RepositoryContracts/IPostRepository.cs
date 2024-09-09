using Entities;

namespace RepositoryContracts;

public interface IPostRepository
{
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Post post);
    Task<Post> GetSingleAsync(int id);
    IQueryable<Post> GetMany();
    Task<Post> LikeAsync(Post post);
    Task<Post> DislikeAsync(Post post);
    
}