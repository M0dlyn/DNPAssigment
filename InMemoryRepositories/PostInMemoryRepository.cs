using System.Formats.Tar;
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class PostInMemoryRepository : IPostRepository 
{

    private List<Post> posts = new List<Post>();
    
    
    public Task<Post> AddAsync(Post post)
    {
        post.Id = posts.Any()
            ? posts.Max(post => post.Id) + 1
            : 1;
        posts.Add(post);
        return Task.FromResult(post);
    }
    
    
    public Task UpdateAsync(Post post)
    {
        Post? existingPost = posts.SingleOrDefault(p => p.Id == post.Id);
        if (existingPost == null)
        {
            throw new InvalidOperationException($"Post with Id ' {post.Id}' does not exist");
        }
        posts.Remove(existingPost);
        posts.Add(post);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Post post)
    {
        Post? postToRemove = posts.SingleOrDefault(p => p.Id == post.Id);
        if (postToRemove is null)
        {
            throw new InvalidOperationException($"Post with Id ' {post.Id}' does not exist");
        }
        posts.Remove(postToRemove);
        return Task.CompletedTask;
    }

    public Task<Post> GetSingleAsync(int id)
    {
        Post? post = posts.SingleOrDefault(p => p.Id == id);
        if (post is null)
        {
            throw new InvalidOperationException($"Post with Id ' {id}' does not exist");
        }
        return Task.FromResult(post);
    }

   

    public IQueryable<Post> GetMany()
    {
        return posts.AsQueryable();
    }
    
    
    
}