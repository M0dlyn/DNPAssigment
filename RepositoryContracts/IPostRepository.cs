using System.Collections.Generic;
using Entities;

public interface IPostRepository
{
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Guid id);
    Task<Post> GetSingleAsync(Guid id);
    IQueryable<Post> GetMany();
    Task<Post> LikeAsync(Post post);
    Task<Post> DislikeAsync(Post post);
    Task<IEnumerable<Post>> GetAllAsync();
}