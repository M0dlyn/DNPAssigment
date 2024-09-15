namespace Entities;

public class SubForum
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }

    public SubForum(String title, String body, int userId)
    {
        this.Title = title;
        this.Body = body;
        this.UserId = userId;
    }
}