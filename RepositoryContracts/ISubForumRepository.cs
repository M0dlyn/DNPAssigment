using Entities;

namespace RepositoryContracts;

public interface ISubForumRepository
{
    Task<SubForum> AddAsync(SubForum forum);
    Task UpdateAsync(SubForum forum);
    Task DeleteAsync(SubForum forum);
    Task<SubForum> GetSingleAsync(int id);
    IQueryable<SubForum> GetMany();
}