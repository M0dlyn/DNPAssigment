namespace ApiContracts;

public class CreateUserDto
{
    public required string Password { get; set; }
 
    public string Name { get; set; }
}