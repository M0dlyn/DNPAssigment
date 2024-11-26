namespace Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string Body { get; set; }

        public Comment() {}

        public Comment(string requestContent, int requestPostId, int requestUserId)
        {
            Content = requestContent;
            PostId = requestPostId;
            UserId = requestUserId;
        }
        // Private constructor for EFC

        public static Comment Create(string content, int postId, int userId)
        {
            return new Comment
            {
                Id = Guid.NewGuid(),
                Content = content,
                PostId = postId,
                UserId = userId,
                Likes = 0,
                Dislikes = 0
            };
        }
    }
}