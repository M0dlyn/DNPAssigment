using RepositoryContracts;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace CLI.UI.ManageUsers;

public class ListUsersView
{
    private readonly IUserRepository userRepository;
    
    public ListUsersView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }


    public async Task ListUsers()
    {
        var users = userRepository.GetMany();
        foreach (var user in users)
        {
            Console.WriteLine($"User ID: {user.Id}");
            Console.WriteLine($"Username: {user.Name}");
        }
    }
    
    public async Task DisplaySingleUser(Guid id)
    {
        var user = await userRepository.GetSingleAsync(id);
        Console.WriteLine($"User ID: {user.Id}");
        Console.WriteLine($"Username: {user.Name}");
    }
    
}