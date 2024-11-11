namespace ApiContracts;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    
    public LoginDto(string Username, string Password)
    {
        this.Username = Username;
        this.Password = Password;
    }
    
    
}