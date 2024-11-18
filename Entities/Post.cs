namespace Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public Guid UserId { get; set; } // Changed from int to Guid
        public User User { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public string Body { get; set; }

        private Post() {} // Private constructor for EFC

        public Post(string title, string content, Guid userId) // Changed from int to Guid
        {
            Title = title;
            Content = content;
            UserId = userId;
            Likes = 0;
            Dislikes = 0;
        }

        public static Post Create(string title, string content, Guid userId) // Changed from int to Guid
        {
            return new Post(title, content, userId);
        }
    }
}