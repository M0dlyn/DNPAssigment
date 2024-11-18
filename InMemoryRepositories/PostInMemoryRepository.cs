using System.Collections.Generic;
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class PostInMemoryRepository : IPostRepository
{
    private List<Post> posts = new List<Post>();

    public PostInMemoryRepository()
    {
        _ = AddAsync(Post.Create("Cat discussion", "Cats are pretty neat, sometimes.", Guid.NewGuid())).Result;
        _ = AddAsync(Post.Create("Cat discussion 2", "Cat dropped a dead bird in my bed. No longer neat.", Guid.NewGuid())).Result;
        _ = AddAsync(Post.Create("Dog discussion", "Dogs are just far superior to cats. EOD.", Guid.NewGuid())).Result;
        _ = AddAsync(Post.Create("Weather?", "So, does anyone else like weather?", Guid.NewGuid())).Result;
        _ = AddAsync(Post.Create("DNP QA", "This post is for DNP discussions, or if you need help with stuff.", Guid.NewGuid())).Result;
        _ = AddAsync(Post.Create("Best lawn mower?", "What's the best lawn mower robot to mow my living room carpet?", Guid.NewGuid())).Result;
    }

    public Task<Post> AddAsync(Post post)
    {
        post.Id = Guid.NewGuid();
        posts.Add(post);
        return Task.FromResult(post);
    }

    public Task UpdateAsync(Post post)
    {
        Post? existingPost = posts.SingleOrDefault(p => p.Id == post.Id);
        if (existingPost == null)
        {
            throw new InvalidOperationException($"Post with Id '{post.Id}' does not exist");
        }
        posts.Remove(existingPost);
        posts.Add(post);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        Post? postToRemove = posts.SingleOrDefault(p => p.Id == id);
        if (postToRemove is null)
        {
            throw new InvalidOperationException($"Post with Id '{id}' does not exist");
        }
        posts.Remove(postToRemove);
        return Task.CompletedTask;
    }

    public Task<Post> GetSingleAsync(Guid id)
    {
        Post? post = posts.SingleOrDefault(p => p.Id == id);
        if (post is null)
        {
            throw new InvalidOperationException($"Post with Id '{id}' does not exist");
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
        if (postToLike == null)
        {
            throw new InvalidOperationException($"Post with Id '{post.Id}' does not exist");
        }
        postToLike.Likes++;
        return Task.FromResult(postToLike);
    }

    public Task<Post> DislikeAsync(Post post)
    {
        Post? postToDislike = posts.SingleOrDefault(p => p.Id == post.Id);
        if (postToDislike == null)
        {
            throw new InvalidOperationException($"Post with Id '{post.Id}' does not exist");
        }
        postToDislike.Dislikes++;
        return Task.FromResult(postToDislike);
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Post>>(posts);
    }
}