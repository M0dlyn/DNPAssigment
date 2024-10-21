namespace ApiContracts;

public class UserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }
    
    public UserDto(int id, string username)
    {
        Username = username;
        Id = id;
        
    }

  
}