using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class CommentInMemoryRepository : ICommentRepository
{
    List<Comment> comments = new List<Comment>();
    List<Comment> commentsOnComment = new List<Comment>();

    public CommentInMemoryRepository()
    {
        _ = AddAsync(Comment.Create("Cats are great!", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("So true!", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("They're just so fluffy", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("Mine's hairless!", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("Is it sick?!", Guid.NewGuid(), Guid.NewGuid())).Result;

        _ = AddAsync(Comment.Create("Cats are still great!", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("Man, mine just spat out a dead mouse :(", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("That's a compliment", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("No rats around my house!", Guid.NewGuid(), Guid.NewGuid())).Result;

        _ = AddAsync(Comment.Create("#FIRST", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("They're just so happy and loving", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("Too noisy for me!", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("Uhhh, no?? Cats forever", Guid.NewGuid(), Guid.NewGuid())).Result;

        _ = AddAsync(Comment.Create("Weather is just the greatest!", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("Not today! It's raining :(", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("Rain just smells so nice", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("Weirdo :O", Guid.NewGuid(), Guid.NewGuid())).Result;

        _ = AddAsync(Comment.Create("HELP!?", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("How do I even do anything?", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("I don't understand async", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("What do you need help with?", Guid.NewGuid(), Guid.NewGuid())).Result;

        _ = AddAsync(Comment.Create("Eh, what? Your carpet?", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("I like my Mowinator3000, it just works", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("It just grows out of control!", Guid.NewGuid(), Guid.NewGuid())).Result;
        _ = AddAsync(Comment.Create("What color is your carpet?", Guid.NewGuid(), Guid.NewGuid())).Result;
    }

    public Task<Comment> AddAsync(Comment comment)
    {
        comment.Id = Guid.NewGuid();
        comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task<List<Comment>> GetAllAsync()
    {
        return Task.FromResult(comments);
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

    public Task DeleteAsync(Guid id)
    {
        Comment? commentToRemove = comments.SingleOrDefault(c => c.Id == id);
        if (commentToRemove is null)
        {
            throw new InvalidOperationException($"Comment with Id '{id}' does not exist");
        }
        comments.Remove(commentToRemove);
        return Task.CompletedTask;
    }

    public Task<Comment> GetSingleAsync(Guid id)
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
        if (postToLike == null)
        {
            throw new InvalidOperationException($"Comment with Id '{comment.Id}' does not exist");
        }
        postToLike.Likes++;
        return Task.FromResult(postToLike);
    }

    public Task<Comment> DislikeAsync(Comment comment)
    {
        Comment? postToDislike = comments.SingleOrDefault(c => c.Id == comment.Id);
        if (postToDislike == null)
        {
            throw new InvalidOperationException($"Comment with Id '{comment.Id}' does not exist");
        }
        postToDislike.Dislikes++;
        return Task.FromResult(postToDislike);
    }

    public Task<Comment> CommentAsync(Comment comment)
    {
        comment.Id = Guid.NewGuid();
        commentsOnComment.Add(comment);
        return Task.FromResult(comment);
    }
}