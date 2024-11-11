namespace ApiContracts;

public class CreatePostDto
{
    public required string Title { get; set; }
    public required string Body { get; set; }
    public  int Id { get; set;}
    
    public CreatePostDto(string title, string body)
    {
        Title = title;
        Body = body;
    }
}