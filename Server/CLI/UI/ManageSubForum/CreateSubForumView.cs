
namespace CLI.UI.ManageSubForum;
using RepositoryContracts;
using Entities;

public class CreateSubForumView
{
    private readonly ISubForumRepository subForumRepository;

    public CreateSubForumView(ISubForumRepository subForumRepository)
    {
        this.subForumRepository = subForumRepository;
    }

    public async Task CreateSubForum(string title, string description)
    {
        var subForum = new SubForum(title, description, 0)
        {
            Title = title,
            Body = description,
            UserId = 0
        };

        await subForumRepository.AddAsync(subForum);
    }
}
