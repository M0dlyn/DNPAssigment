namespace ApiContracts;

public class CommentDto
{
    public int Id { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }
    
    public int PostId { get; set; }
    
    public CommentDto(int id, string body, int postId, int userId)
    {
        this.Body = body;
        this.UserId = userId;
        this.PostId = postId;
    }
}