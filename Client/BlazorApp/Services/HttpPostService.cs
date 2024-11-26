using System.Text.Json;
using ApiContracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services;
    



public class HttpPostService : IPostService
{
   
    private readonly HttpClient client;
    private readonly EfcRepositories.AppContext context;

    public HttpPostService(HttpClient client, EfcRepositories.AppContext context)
    {
        this.client = client;
        this.context = context;
    }
    
    public async Task<PostDto> AddPostAsync(CreatePostDto request)
    {
        var post = new Post
        {
            Title = request.Title,
            Body = request.Body,
            UserId = request.UserId
        };

        context.Posts.Add(post);
        await context.SaveChangesAsync();

        return new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Body = post.Body
        };
    }
    
    
    public async Task<PostDto> UpdatePostAsync(int id, UpdatePostDto request)
    {
        var post = await context.Posts.FindAsync(id);
        if (post == null)
        {
            throw new Exception("Post not found");
        }

        post.Update(request.Title, request.Body);
        await context.SaveChangesAsync();

        return new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Body = post.Body
        };
    }
    

    
    public async Task<PostDto> DeletePostAsync(int id)
    {
        var post = await context.Posts.FindAsync(id);
        if (post == null)
        {
            throw new Exception("Post not found");
        }

        context.Posts.Remove(post);
        await context.SaveChangesAsync();

        return new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Body = post.Body
        };
    }
    

    
    public async Task<PostDto> GetPostAsync(int id)
    {
        var post = await context.Posts.FindAsync(id);
        if (post == null)
        {
            throw new Exception("Post not found");
        }

        return new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Body = post.Body
        };
    }
    

    
    public async Task<List<PostDto>> GetPostsAsync()
    {
        var posts = await context.Posts.ToListAsync();

        return posts.Select(post => new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Body = post.Body
        }).ToList();
    }
    
    
    
    
}