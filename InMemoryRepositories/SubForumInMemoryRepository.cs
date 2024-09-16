using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class SubForumInMemoryRepository : ISubForumRepository
{
    private List<SubForum> forums = new List<SubForum>();
   

    
    
    public Task<SubForum> AddAsync(SubForum forum)
    {
        forum.Id = forums.Any()
            ? forums.Max(post => post.Id) + 1
            : 1;
        forums.Add(forum);
        return Task.FromResult(forum);
    }
    
    
    public Task UpdateAsync(SubForum forum)
    {
        SubForum? existingPost = forums.SingleOrDefault(p => p.Id == forum.Id);
        if (existingPost == null)
        {
            throw new InvalidOperationException($"SubForum with Id ' {forum.Id}' does not exist");
        }
        forums.Remove(existingPost);
        forums.Add(forum);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(SubForum forum)
    {
        SubForum? forumToRemove = forums.SingleOrDefault(p => p.Id == forum.Id);
        if (forumToRemove is null)
        {
            throw new InvalidOperationException($"SubForum with Id ' {forum.Id}' does not exist");
        }
        forums.Remove(forumToRemove);
        return Task.CompletedTask;
    }

    public Task<SubForum> GetSingleAsync(int id)
    {
        SubForum? forum = forums.SingleOrDefault(p => p.Id == id);
        if (forums is null)
        {
            throw new InvalidOperationException($"SubForum with Id ' {id}' does not exist");
        }
        return Task.FromResult(forum);
    }

   

    public IQueryable<SubForum> GetMany()
    {
        return forums.AsQueryable();
    }

   
}