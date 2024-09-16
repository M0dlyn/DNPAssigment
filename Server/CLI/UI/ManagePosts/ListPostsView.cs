using RepositoryContracts;


namespace CLI.UI.ManagePosts;

public class ListPostsView
{
    
    private readonly IPostRepository postRepository;
    private readonly IUserRepository userRepository;
    private readonly ICommentRepository commentRepository;
    
    
    public ListPostsView(IPostRepository postRepository, IUserRepository userRepository, ICommentRepository commentRepository)
    {
        this.postRepository = postRepository;
        this.userRepository = userRepository;
        this.commentRepository = commentRepository;
    }
    
    
    public async Task ListPosts()
    {
        var posts = postRepository.GetMany();
       
        foreach (var post in posts)
        {
            var user = await userRepository.GetSingleAsync(post.UserId);
            var comments = commentRepository.GetMany().Where(c => c.PostId == post.Id);
            Console.WriteLine($"Post ID: {post.Id}");
            Console.WriteLine($"Post Title: {post.Title}");
            Console.WriteLine($"Post Content: {post.Body}");
            Console.WriteLine($"Post Author: {user.Username}");
            Console.WriteLine($"Post Comments:");
            foreach (var comment in comments)
            {
                var commentUser = await userRepository.GetSingleAsync(comment.UserId);
                Console.WriteLine($"Comment ID: {comment.Id}");
                Console.WriteLine($"Comment Body: {comment.Body}");
                Console.WriteLine($"Comment Author: {commentUser.Username}");
            }
            Console.WriteLine();
        }
    }
    
    
    
    
    public async Task DisplaySinglePost(int id)
    {
        var post = await postRepository.GetSingleAsync(id);
        var user = await userRepository.GetSingleAsync(post.UserId);
        var comments = commentRepository.GetMany().Where(c => c.PostId == post.Id);
        Console.WriteLine($"Post ID: {post.Id}");
        Console.WriteLine($"Post Title: {post.Title}");
        Console.WriteLine($"Post Content: {post.Body}");
        Console.WriteLine($"Post Author: {user.Username}");
        Console.WriteLine($"Post Comments:");
        foreach (var comment in comments)
        {
            var commentUser = await userRepository.GetSingleAsync(comment.UserId);
            Console.WriteLine($"Comment ID: {comment.Id}");
            Console.WriteLine($"Comment Body: {comment.Body}");
            Console.WriteLine($"Comment Author: {commentUser.Username}");
        }
        Console.WriteLine();
    }
    
    
}