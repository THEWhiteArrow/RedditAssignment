using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")] 
public class PostsController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostsController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationDto dto)
    {
        
        try
        {
            Post post = await postLogic.CreateAsync(dto); 
            return Created($"/posts/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message + "...Error here...");
        }
    }

    [HttpGet, Route("test")]
    public ActionResult Test()
    {
        return Ok("Authenticated");
    }

    [HttpGet, AllowAnonymous]
    public async Task<ActionResult<Post>> GetAsync([FromQuery] string? ownerusername, [FromQuery] int? id,
        [FromQuery] string? titlecontains, [FromQuery] string? title)
    {
        try
        {
            SearchPostParametersDto parametersDto = new SearchPostParametersDto(id ?? -1, title,titlecontains,ownerusername);
            IEnumerable<Post> posts = await postLogic.GetAsync(parametersDto);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }
    
    
     

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Post>> GetByIdAsync([FromRoute] int id)
    {
        try
        {
            Post? todo = await postLogic.GetByIdAsync(id);
            return Ok(todo);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}