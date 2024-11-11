using System.Text.Json;
using ApiContracts;
namespace BlazorApp.Services;
    



public class HttpPostService : IPostService
{
    private readonly HttpClient client;
    
    public HttpPostService(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<PostDto> AddPostAsync(CreatePostDto request)
    {
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync("api/posts", request);
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<PostDto>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
    
    public async Task UpdatePostAsync(UpdatePostDto request)
    {
        HttpResponseMessage httpResponse = await client.PutAsJsonAsync($"api/posts/{request}", request);
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
    }

    public async Task DeletePostAsync(Guid id)
    {
        HttpResponseMessage httpResponse = await client.DeleteAsync($"api/posts/{id}");
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
    }

    public async Task<UserDto> GetPostAsync(Guid id)
    {
        HttpResponseMessage httpResponse = await client.GetAsync($"api/posts/{id}");
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<UserDto>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    public async Task<List<PostDto>> GetPostsAsync()
    {
        HttpResponseMessage httpResponse = await client.GetAsync("api/posts");
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<List<PostDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
    
    
    
}