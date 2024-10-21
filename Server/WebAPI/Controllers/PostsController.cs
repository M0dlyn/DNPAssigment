using ApiContracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostRepository postRepo;

    public PostsController(IPostRepository postRepo)
    {
        this.postRepo = postRepo;
    }

    [HttpPost]
    public async Task<ActionResult<PostDto>> CreatePost([FromBody] CreatePostDto request)
    {
        try
        {
            Post post = new(request.Title, request.Body, request.Id);
            Post created = await postRepo.AddAsync(post);
            PostDto postDto = new(created.Title, created.Body, created.Id);
            return Created($"/Posts/{postDto.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdatePostDto request)
    {
        try
        {
            Post post = await postRepo.GetSingleAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            post.Update(request.Title, request.Body);
            await postRepo.UpdateAsync(post);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> GetSinglePost(int id)
    {
        try
        {
            Post post = await postRepo.GetSingleAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetManyPosts([FromQuery] string? title = null, [FromQuery] string? body = null)
    {
        try
        {
            IEnumerable<Post> posts = postRepo.GetMany();
            IEnumerable<PostDto> postDtos = posts.Select(post => new PostDto(post.Title, post.Body, post.Id));
            return Ok(postDtos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        try
        {
            Post post = await postRepo.GetSingleAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            await postRepo.DeleteAsync(post.Id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}