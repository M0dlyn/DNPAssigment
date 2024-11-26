namespace ApiContracts;

public class PostDto
{
    public string Title { get; set; }
    public string Body { get; set; }
    public int Id { get; set; }
    public int UserId  { get; set; }
    
    public PostDto(string title, string body, int id, int userId)
    {
        Title = title;
        Body = body;
        Id = id;
        UserId = userId;
    }
    

   
}