using CLI.UI.ManageSubForum;

namespace CLI.UI;

using InMemoryRepositories;
using RepositoryContracts;


public class CliApp
{

    private readonly IUserRepository userRepository;
    private readonly ICommentRepository commentRepository;
    private readonly IPostRepository postRepository;
    private readonly ISubForumRepository subForumRepository;
    
    

    public CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository, ISubForumRepository subForumRepository)
    {
        this.userRepository = userRepository;
        this.commentRepository = commentRepository;
        this.postRepository = postRepository;
        this.subForumRepository = subForumRepository;
    }
   

    public async Task StartAsync()
    {
        Console.WriteLine("CLI App started...");
        var subForumView = new CreateSubForumView(subForumRepository);
        var 
        await subForumView.CreateSubForum("New SubForum", "Description of the new subforum");

        Console.WriteLine("SubForum created successfully.");
    }
}