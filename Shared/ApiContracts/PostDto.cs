namespace ApiContracts;

public class PostDto
{
    public string Title;
    public string Body;
    public int Id;

    public PostDto(string Title, string Body, int Id)
    {
        this.Title = Title;
        this.Body = Body;
        this.Id = Id;
    }
}