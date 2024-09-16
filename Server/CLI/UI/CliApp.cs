namespace CLI.UI;

using InMemoryRepositories;
using RepositoryContracts;


public class CliApp
{

    public CliApp()
    {
        
    }

    public CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository)
    {
        throw new NotImplementedException();
    }

    public async Task StartAsync()
    {
        throw new NotImplementedException();
    }
}