namespace ApiContracts;

public class CreatePostDto
{
    public string Title { get; set; }
    public string Body { get; set; }
    public int Id { get; set; }

    public int UserId { get; set; }
    

    
}