namespace ApiContracts;

public class PostDto
{
    public string Title;
    public string Body;
    public Guid Id;

    public PostDto(string Title, string Body, Guid Id)
    {
        this.Title = Title;
        this.Body = Body;
        this.Id = Id;
    }
}