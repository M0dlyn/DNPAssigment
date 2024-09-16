namespace CLI.UI.ManagePosts;
using InMemoryRepositories;
using RepositoryContracts;

public class CreatePostView
{
    private readonly IPostRepository postRepository;


    public CreatePostView(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }
}