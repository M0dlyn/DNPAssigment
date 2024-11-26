using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ManageUsersView
{
    private List<User> users;
    private readonly IUserRepository userRepository;
    
    public ManageUsersView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    
    public void AddUser(User user)
    {
        userRepository.AddAsync(user);
    }
    
    public void DeleteUser(Guid id)
    {
        userRepository.DeleteAsync(id);
    }
    
    
    public void UpdateUser(Guid id, User user)
    {
        userRepository.UpdateAsync(id, user);
    }
    
    
    public void GetSingleUser(Guid id)
    {
        userRepository.GetSingleAsync(id);
    }
}