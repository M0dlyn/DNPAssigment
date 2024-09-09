using System.Formats.Tar;
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class CommentInMemoryRepository : ICommentRepository
{
    
    List<Comment> comments = new List<Comment>();
    private int likes = 0; 
    private int dislikes = 0;
    List<Comment> commentsOnComment = new List<Comment>();


    public Task<Comment> AddAsync(Comment comment)
    {
        comment.Id = comments.Any()
            ? comments.Max(comment => comment.Id) + 1
            : 1;
        comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task UpdateAsync(Comment comment)
    {
        Comment? existingComment = comments.SingleOrDefault(c => c.Id == comment.Id);
        if (existingComment == null)
        {
            throw new InvalidOperationException($"Comment with Id '{comment.Id}' does not exist");
        }
        comments.Remove(existingComment);
        comments.Add(comment);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Comment? commentToRemove = comments.SingleOrDefault(c => c.Id == id);
        if (commentToRemove is null)
        {
            throw new InvalidOperationException($"Comment with Id '{id}' does not exist");
        }
        comments.Remove(commentToRemove);
        return Task.CompletedTask;
    }

    public Task<Comment> GetSingleAsync(int id)
    {
        Comment? comment = comments.SingleOrDefault(c => c.Id == id);
        if (comment is null)
        {
            throw new InvalidOperationException($"Comment with Id '{id}' does not exist");
        }
        return Task.FromResult(comment);
    }

    public IQueryable<Comment> GetMany()
    {
        return comments.AsQueryable();
    }
    
    public Task<Comment> LikeAsync(Comment comment)
    {
        Comment? postToLike = comments.SingleOrDefault(c => c.Id == comment.Id);

        likes++;
        
        return Task.FromResult(postToLike ?? comment);
    }

    public Task<Comment> DislikeAsync(Comment comment)
    {
        Comment? postToDislike = comments.SingleOrDefault(c => c.Id == comment.Id);

        dislikes++;
        
        return Task.FromResult(postToDislike ?? comment);
    }

    public Task<Comment> CommentAsync(Comment comment)
    {
        comment.Id = commentsOnComment.Any()
            ? commentsOnComment.Max(comment => comment.Id) + 1
            : 1;
        commentsOnComment.Add(comment);
        return Task.FromResult(comment);
        
    }
        
    
}