using System.Collections.Generic;
using Entities;

public interface IPostRepository
{
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);
    Task<Post> GetSingleAsync(Guid id);
    IQueryable<Post> GetMany();
  
    Task<IEnumerable<Post>> GetAllAsync();
}