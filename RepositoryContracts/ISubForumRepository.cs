using Entities;

namespace RepositoryContracts;

public interface ISubForumRepository
{
    Task<SubForum> AddAsync(SubForum forum);
    Task<SubForum> UpdateAsync(SubForum forum);
    Task<SubForum> DeleteAsync(SubForum forum);
    Task<SubForum> GetSingleAsync(int id);
    IQueryable<SubForum> GetMany();
}