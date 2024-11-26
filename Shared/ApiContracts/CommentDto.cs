// CommentDto.cs
namespace ApiContracts
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        public CommentDto(Guid id, string content, int postId, int userId)
        {
            Id = id;
            Content = content;
            PostId = postId;
            UserId = userId;
        }
    }
}