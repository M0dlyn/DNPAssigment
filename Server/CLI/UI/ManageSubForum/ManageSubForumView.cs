using RepositoryContracts;

namespace CLI.UI.ManageSubForum;
using Entities;
using RepositoryContracts;
public class ManageSubForumView
{
    private List<SubForum> subForums;
    private readonly ISubForumRepository postRepository;
    
    public ManageSubForumView(ISubForumRepository postRepository)
    {
        this.postRepository = postRepository;
    }
    
    public void AddSubForum(SubForum subForum)
    {
        postRepository.AddAsync(subForum);
    }
    
    public void DeleteSubForum(SubForum subForum)
    {
        postRepository.DeleteAsync(subForum);
    }
    
    public void UpdateSubForum(SubForum subForum)
    {
        postRepository.UpdateAsync(subForum);
    }
    
}