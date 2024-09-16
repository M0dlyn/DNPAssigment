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
    
    public async Task CreateComment(int postId, int userId, string commentBody)
    {
        var comment = new Comment(commentBody,userId,postId)
        {
            PostId = postId,
            UserId = userId,
            Body = commentBody,
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
    
    public async Task ListComments()
    {
        var comments = commentRepository.GetMany();
        
        foreach (var comment in comments)
        {
            var user = await userRepository.GetSingleAsync(comment.UserId);
            var post = await postRepository.GetSingleAsync(comment.PostId);
            Console.WriteLine($"Comment ID: {comment.Id}");
            Console.WriteLine($"Comment Body: {comment.Body}");
            Console.WriteLine($"Comment Author: {user.Username}");
            Console.WriteLine($"Comment Post: {post.Title}");
            Console.WriteLine();
        }
    }
    
        
    
    
    
    
}