namespace Entities;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }


    public User(String username, String password)
    {
        this.Username = username;
        this.Password = password;
    }
    
    
}