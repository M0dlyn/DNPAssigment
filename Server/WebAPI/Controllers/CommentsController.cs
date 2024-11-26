using ApiContracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentRepository commentRepo;

    public CommentsController(ICommentRepository commentRepo)
    {
        this.commentRepo = commentRepo;
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> CreateComment([FromBody] CreateCommentDto request)
    {
        try
        {
            Comment comment = new Comment { Content = request.Content, PostId = request.PostId, UserId = request.UserId };
            Comment created = await commentRepo.AddAsync(comment);
            CommentDto commentDto = new(created.Id, created.Content, created.UserId, created.PostId);
            return Created($"/Comments/{created.Id}", commentDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDto>> GetSingleComment([FromRoute] Guid id)
    {
        try
        {
            Comment result = await commentRepo.GetSingleAsync(id);
            CommentDto commentDto = new(result.Id, result.Content, result.UserId, result.PostId);
            return Ok(commentDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteComment([FromRoute] Guid id)
    {
        try
        {
            await commentRepo.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<CommentDto>>> GetComments()
    {
        List<Comment> comments = await commentRepo.GetAllAsync();
        List<CommentDto> result = comments.Select(comment => new CommentDto(comment.Id, comment.Content, comment.PostId, comment.UserId)).ToList();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CommentDto>> UpdateComment([FromRoute] Guid id, [FromBody] UpdateCommentDto request)
    {
        try
        {
            Comment comment = await commentRepo.GetSingleAsync(id);
            comment.Content = request.Content;
            await commentRepo.UpdateAsync(comment);
            CommentDto commentDto = new(comment.Id, comment.Content, comment.UserId, comment.PostId);
            return Ok(commentDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}