using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryContracts;

namespace EfcRepositories;

public class EfcUserRepository : IUserRepository
{
    private readonly AppContext ctx;

    public EfcUserRepository(AppContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<User> AddAsync(User user)
    {
        EntityEntry<User> entityEntry = await ctx.Users.AddAsync(user);
        await ctx.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await ctx.Users.ToListAsync();
    }

    public async Task UpdateAsync(User user)
    {
        if (!(await ctx.Users.AnyAsync(u => u.Id == user.Id)))
        {
            throw new NotFoundException($"User with id {user.Id} not found");
        }
        ctx.Users.Update(user);
        await ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        User? user = await ctx.Users.FindAsync(id);
        if (user == null)
        {
            throw new NotFoundException($"User with id {id} not found");
        }
        ctx.Users.Remove(user);
        await ctx.SaveChangesAsync();
    }

    public async Task<User> GetSingleAsync(Guid id)
    {
        User? user = await ctx.Users.FindAsync(id);
        if (user == null)
        {
            throw new NotFoundException($"User with id {id} not found");
        }
        return user;
    }

    public IQueryable<User> GetMany()
    {
        return ctx.Users.AsQueryable();
    }
}