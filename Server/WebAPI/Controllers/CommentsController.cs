using ApiContracts;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
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
            Comment comment = new Comment(request.Content, request.PostId, request.UserId);
            Comment created = await commentRepo.AddAsync(comment);
            CommentDto commentDto = new(created.Id, created.Body, created.UserId, created.PostId);
            return Created($"/Comments/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }

    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDto>> GetSingleComment([FromRoute]int id)
    {
        try
        {
            Comment result =  await commentRepo.GetSingleAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<CommentDto>> DeleteComment([FromRoute]int id)
    {
           
            await commentRepo.DeleteAsync(id);
            return NoContent();       
        
    }
    
    [HttpGet("post/{postId}")]
    public async Task<ActionResult<IQueryable<CommentDto>>> GetCommentsFromPostId([FromRoute] int postId)
    {
        IQueryable<Comment> comments = commentRepo.GetMany().Where(c => c.PostId == postId);
        List<CommentDto> result = comments.Select(comment => new CommentDto(comment.Id, comment.Body, comment.PostId, comment.UserId)).ToList();
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<CommentDto>> UpdateComment([FromRoute]int id, [FromBody] UpdateCommentDto request)
    {
        try
        {
            Comment comment = await commentRepo.GetSingleAsync(id);
            comment.Body = request.Body;
            await commentRepo.UpdateAsync(comment);
            return Ok(comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
}