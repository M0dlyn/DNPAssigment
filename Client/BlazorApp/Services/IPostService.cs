using ApiContracts;

namespace BlazorApp.Services;

public interface IPostService
{
    public Task<PostDto> AddPostAsync(CreatePostDto request);
    public Task UpdatePostAsync(UpdatePostDto request);
    public Task DeletePostAsync(Guid id);
    public Task<UserDto> GetPostAsync(Guid id);
    public Task<List<PostDto>> GetPostsAsync();
}