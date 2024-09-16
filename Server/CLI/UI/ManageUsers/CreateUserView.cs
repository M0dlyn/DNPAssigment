namespace CLI.UI.ManageUsers;
using InMemoryRepositories;
using RepositoryContracts;

public class CreateUserView
{
    
    private readonly IUserRepository userRepository;

    public CreateUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    
}