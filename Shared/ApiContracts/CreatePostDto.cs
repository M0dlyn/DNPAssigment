namespace ApiContracts;

public class CreatePostDto
{
    public required string Title { get; set; }
    public required string Body { get; set; }
    public  Guid Id { get; set;}
    
    public CreatePostDto(string title, string body, Guid Id)
    {
        Title = title;
        Body = body;
        Id= Id;
    }
}