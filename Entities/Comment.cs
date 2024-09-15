namespace Entities;

public class Comment
{
    public int Id { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }
    
    public int PostId { get; set; }


    public Comment(String body, int postId, int userId )
    {
        this.Body = body;
        this.UserId = userId;
        this.PostId = postId;
    }
}