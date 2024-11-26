// CommentDto.cs
namespace ApiContracts
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }

        public CommentDto(Guid id, string content, Guid postId, Guid userId)
        {
            Id = id;
            Content = content;
            PostId = postId;
            UserId = userId;
        }
    }
}