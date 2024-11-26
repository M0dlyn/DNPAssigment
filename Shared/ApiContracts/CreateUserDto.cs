namespace ApiContracts;

public class CreateUserDto
{
    public required string Password { get; set; }
    public required string Email { get; set; }
    public string Name { get; set; }
}