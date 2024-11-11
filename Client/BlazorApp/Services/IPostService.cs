using ApiContracts;

namespace BlazorApp.Services;

public interface IPostService
{
    public Task<PostDto> AddPostAsync(CreatePostDto request);
    public Task<PostDto> UpdatePostAsync(int id,UpdatePostDto request);
    public Task<PostDto> DeletePostAsync(int id);
    public Task<PostDto> GetPostAsync(int id);
    public Task<List<PostDto>> GetPostsAsync();
}