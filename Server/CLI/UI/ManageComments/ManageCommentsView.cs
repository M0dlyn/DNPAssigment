namespace CLI.UI.ManageComments;
using Entities;
using RepositoryContracts;
public class ManageCommentsView
{
    private readonly ICommentRepository commentRepository;
    private List<Comment> comments;

    
    public ManageCommentsView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }
    
    
    public async Task CreateComment(Guid postId, Guid userId, string commentBody)
    {
        var comment = new Comment
        {
            PostId = postId,
            UserId = userId,
            Body = commentBody
        };

        await commentRepository.AddAsync(comment);
    }
    
    public async Task DeleteComment(Guid id)
    {
        await commentRepository.DeleteAsync(id);
    }
    
    public async Task UpdateComment(Guid id, string newBody)
    {
        var comment = await commentRepository.GetSingleAsync(id);
        comment.Body = newBody;
        await commentRepository.UpdateAsync(comment);
    }
    
    public async Task GetSingleComment(Guid id)
    {
        await commentRepository.GetSingleAsync(id);
    }
    
    
    
    
    
}