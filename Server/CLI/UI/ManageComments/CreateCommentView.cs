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
    
}