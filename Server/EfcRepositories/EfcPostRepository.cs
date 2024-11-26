using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcRepositories;

public class EfcPostRepository : IPostRepository
{
    private readonly AppContext ctx;

    public EfcPostRepository(AppContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<Post> AddAsync(Post post)
    {
        EntityEntry<Post> entityEntry = await ctx.Posts.AddAsync(post);
        await ctx.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(Post post)
    {
        if (!(await ctx.Posts.AnyAsync(p => p.Id == post.Id)))
        {
            throw new NotFoundException($"Post with id {post.Id} not found");
        }
        ctx.Posts.Update(post);
        await ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Post? post = await ctx.Posts.FindAsync(id);
        if (post == null)
        {
            throw new NotFoundException($"Post with id {id} not found");
        }
        ctx.Posts.Remove(post);
        await ctx.SaveChangesAsync();
    }

    public async Task<Post> GetSingleAsync(Guid id)
    {
        Post? post = await ctx.Posts.FindAsync(id);
        if (post == null)
        {
            throw new NotFoundException($"Post with id {id} not found");
        }
        return post;
    }

    public IQueryable<Post> GetMany()
    {
        return ctx.Posts.AsQueryable();
    }

 

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await ctx.Posts.ToListAsync();
    }
}