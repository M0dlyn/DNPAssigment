using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

using RepositoryContracts;
using static ICommentRepository;

public class CreateCommentView
{
    private readonly ICommentRepository commentRepository;
    
    public CreateCommentView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }
    public async Task CreateComment(Guid postId, Guid userId, string commentBody)
    {
        var comment = new Comment
        {
            PostId = postId,
            UserId = userId,
            Body = commentBody,
        };

        await commentRepository.AddAsync(comment);
    }
    
}