using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryContracts;

namespace EfcRepositories;

public class EfcCommentRepository : ICommentRepository
{
    private readonly AppContext ctx;

    public EfcCommentRepository(AppContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<Comment> AddAsync(Comment comment)
    {
        EntityEntry<Comment> entityEntry = await ctx.Comments.AddAsync(comment);
        await ctx.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await ctx.Comments.ToListAsync();
    }

    public async Task UpdateAsync(Comment comment)
    {
        if (!(await ctx.Comments.AnyAsync(c => c.Id == comment.Id)))
        {
            throw new NotFoundException($"Comment with id {comment.Id} not found");
        }
        ctx.Comments.Update(comment);
        await ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        Comment? comment = await ctx.Comments.FindAsync(id);
        if (comment == null)
        {
            throw new NotFoundException($"Comment with id {id} not found");
        }
        ctx.Comments.Remove(comment);
        await ctx.SaveChangesAsync();
    }

    public async Task<Comment> GetSingleAsync(Guid id)
    {
        Comment? comment = await ctx.Comments.FindAsync(id);
        if (comment == null)
        {
            throw new NotFoundException($"Comment with id {id} not found");
        }
        return comment;
    }

    public IQueryable<Comment> GetMany()
    {
        return ctx.Comments.AsQueryable();
    }
}