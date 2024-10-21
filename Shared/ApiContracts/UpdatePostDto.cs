namespace ApiContracts
{
    public class UpdatePostDto
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public UpdatePostDto(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}