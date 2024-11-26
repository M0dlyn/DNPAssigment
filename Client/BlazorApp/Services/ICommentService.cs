using ApiContracts;

namespace BlazorApp.Services;

public interface ICommentService
{
    public Task<CommentDto> AddCommentAsync(CreateCommentDto request);
    public Task<CommentDto> UpdateCommentAsync(int id, UpdateCommentDto request);
    public Task<CommentDto> DeleteCommentAsync(int id);
    public Task<CommentDto> GetCommentAsync(int id);
    public Task<List<CommentDto>> GetCommentsForPostAsync(int postId);
}