using System.Formats.Tar;
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class PostInMemoryRepository : IPostRepository 
{

    private List<Post> posts = new List<Post>();
    private int likes = 0;
    private int dislikes = 0;

    
    public PostInMemoryRepository()
    {
        _ = AddAsync(new Post("Cat discussion", "Cats are pretty neat, sometimes.", 1)).Result;
        _ = AddAsync(new Post("Cat discussion 2", "Cat dropped a dead bird in my bed. No longer neat.", 1)).Result;
        _ = AddAsync(new Post("Dog discussion", "Dogs are just far superior to cats. EOD.", 3)).Result;
        _ = AddAsync(new Post("Weather?", "So, does anyone else like weather?", 2)).Result;
        _ = AddAsync(new Post("DNP QA", "This post is for DNP discussions, or if you need help with stuff.", 4)).Result;
        _ = AddAsync(new Post("Best lawn mower?", "What's the bet lawn mower robot to mow my living room carpet?", 3)).Result;
    }
    
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

    public Task<Post> LikeAsync(Post post)
    {
        Post? postToLike = posts.SingleOrDefault(p => p.Id == post.Id);
        likes++;
        return Task.FromResult(postToLike ?? post);
    }

    public Task<Post> DislikeAsync(Post post)
    {
        Post? postToDislike = posts.SingleOrDefault(p => p.Id == post.Id);
        dislikes++;
        return Task.FromResult(postToDislike ?? post);
    }
    
    
    
    
}