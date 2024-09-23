using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace FileRepositories;

public class SubForumFileRepository : ISubForumRepository
{
    private readonly string filePath = "subForums.json";
    
    public SubForumFileRepository()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }
    public async Task<SubForum> AddAsync(SubForum subForum)
    {
        string subForumsAsJson = await File.ReadAllTextAsync(filePath);
        List<SubForum> subForums = JsonSerializer.Deserialize<List<SubForum>>(subForumsAsJson);
        int maxId = subForums.Count > 0 ? subForums.Max(s => s.Id) : 1;
        subForum.Id = maxId + 1;
        subForums.Add(subForum);
        subForumsAsJson = JsonSerializer.Serialize(subForums);
        await File.WriteAllTextAsync(filePath, subForumsAsJson);
        return subForum;
    }
    
    public async Task UpdateAsync(SubForum subForum)
    {
        string subForumsAsJson = await File.ReadAllTextAsync(filePath);
        List<SubForum> subForums = JsonSerializer.Deserialize<List<SubForum>>(subForumsAsJson);
        SubForum? existingSubForum = subForums.SingleOrDefault(s => s.Id == subForum.Id);
        if (existingSubForum == null)
        {
            throw new InvalidOperationException($"SubForum with Id ' {subForum.Id}' does not exist");
        }
        subForums.Remove(existingSubForum);
        subForums.Add(subForum);
        subForumsAsJson = JsonSerializer.Serialize(subForums);
        await File.WriteAllTextAsync(filePath, subForumsAsJson);
    }

    public Task DeleteAsync(SubForum forum)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        string subForumsAsJson = await File.ReadAllTextAsync(filePath);
        List<SubForum> subForums = JsonSerializer.Deserialize<List<SubForum>>(subForumsAsJson);
        SubForum? subForumToRemove = subForums.SingleOrDefault(s => s.Id == id);
        if (subForumToRemove is null)
        {
            throw new InvalidOperationException($"SubForum with Id ' {id}' does not exist");
        }
        subForums.Remove(subForumToRemove);
        subForumsAsJson = JsonSerializer.Serialize(subForums);
        await File.WriteAllTextAsync(filePath, subForumsAsJson);
    }
    
    public async Task<SubForum> GetSingleAsync(int id)
    {
        string subForumsAsJson = await File.ReadAllTextAsync(filePath);
        List<SubForum> subForums = JsonSerializer.Deserialize<List<SubForum>>(subForumsAsJson);
        SubForum? subForum = subForums.SingleOrDefault(s => s.Id == id);
        if (subForum is null)
        {
            throw new InvalidOperationException($"SubForum with Id ' {id}' does not exist");
        }
        return subForum;
    }
    
    public IQueryable<SubForum> GetMany()
    {
        string subForumsAsJson = File.ReadAllText(filePath);
        List<SubForum> subForums = JsonSerializer.Deserialize<List<SubForum>>(subForumsAsJson);
        return subForums.AsQueryable();
    }
    
    
    
    
    
}