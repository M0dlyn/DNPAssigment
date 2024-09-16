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
    
    
    public async Task CreateComment(int postId, int userId, string commentBody)
    {
        var comment = new Comment(commentBody,userId,postId)
        {
            PostId = postId,
            UserId = userId,
            Body = commentBody
        };

        await commentRepository.AddAsync(comment);
    }
    
    public async Task DeleteComment(int id)
    {
        await commentRepository.DeleteAsync(id);
    }
    
    public async Task UpdateComment(int id, string newBody)
    {
        var comment = await commentRepository.GetSingleAsync(id);
        comment.Body = newBody;
        await commentRepository.UpdateAsync(comment);
    }
    
    public async Task GetSingleComment(int id)
    {
        await commentRepository.GetSingleAsync(id);
    }
    
    
    
    
    
}