namespace CLI.UI.ManageComments;
using RepositoryContracts;
using Entities;

public class ListCommentsView
{
    private readonly IPostRepository postRepository;
    private readonly IUserRepository userRepository;
    private readonly ICommentRepository commentRepository;
    
    public ListCommentsView(IPostRepository postRepository, IUserRepository userRepository, ICommentRepository commentRepository)
    {
        this.postRepository = postRepository;
        this.userRepository = userRepository;
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

    public async Task ListComments()
    {
        var comments = await commentRepository.GetAllAsync();

        foreach (var comment in comments)
        {
            var user = await userRepository.GetSingleAsync(comment.UserId);
            var post = await postRepository.GetSingleAsync(comment.PostId);
            Console.WriteLine($"Comment ID: {comment.Id}");
            Console.WriteLine($"Comment Body: {comment.Body}");
            Console.WriteLine($"Comment Author: {user.Name}");
            Console.WriteLine($"Comment Post: {post.Title}");
            Console.WriteLine();
        }
    }
    
        
    
    
    
    
}