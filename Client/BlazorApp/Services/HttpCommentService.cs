using System.Text.Json;
using ApiContracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services;

public class HttpCommentService : ICommentService
{
    private readonly HttpClient client;
    private readonly EfcRepositories.AppContext context;

    public HttpCommentService(HttpClient client, EfcRepositories.AppContext context)
    {
        this.client = client;
        this.context = context;
    }
    public async Task<CommentDto> AddCommentAsync(CreateCommentDto request)
    {
        var comment = new Comment
        {
            Body = request.Content,
            PostId = request.PostId,
            UserId = request.UserId
        };

        context.Comments.Add(comment);
        await context.SaveChangesAsync();

        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Body,
            PostId = comment.PostId,
            UserId = comment.UserId
        };
    }

    
    public async Task<CommentDto> UpdateCommentAsync(int id, UpdateCommentDto request)
    {
        var comment = await context.Comments.FindAsync(id);
        if (comment == null)
        {
            throw new Exception("Comment not found");
        }

        comment.Body = request.Content;
        await context.SaveChangesAsync();

        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Body,
            PostId = comment.PostId,
            UserId = comment.UserId
        };
    }
    

    
    public async Task<CommentDto> DeleteCommentAsync(int id)
    {
        var comment = await context.Comments.FindAsync(id);
        if (comment == null)
        {
            throw new Exception("Comment not found");
        }

        context.Comments.Remove(comment);
        await context.SaveChangesAsync();

        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Body,
            PostId = comment.PostId,
            UserId = comment.UserId
        };
    }
    

    
    public async Task<CommentDto> GetCommentAsync(int id)
    {
        var comment = await context.Comments.FindAsync(id);
        if (comment == null)
        {
            throw new Exception("Comment not found");
        }

        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Body,
            PostId = comment.PostId,
            UserId = comment.UserId
        };
    }
    

    
    public async Task<List<CommentDto>> GetCommentsForPostAsync(int postId)
    {
        var comments = await context.Comments.Where(c => c.PostId == postId).ToListAsync();

        return comments.Select(comment => new CommentDto
        {
            Id = comment.Id,
            Content = comment.Body,
            PostId = comment.PostId,
            UserId = comment.UserId
        }).ToList();
    }
    

}