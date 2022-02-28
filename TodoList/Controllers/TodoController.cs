using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using TodoList.Models;

namespace TodoList.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    private readonly TodoList _todoService;
    public TodoListController(TodoList todoService)
    {
        _todoService = todoService; 
    }

    [HttpPost("add")]
    public IActionResult AddTodo([FromBody]string name)
    {
        ListModel model = new ListModel()
        {
            Name = name
        };
        try
        {
            _todoService.AddToDo(model);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet("get")]
    public ActionResult<List<ListModel>> GetTodo()
    {
        return Ok(_todoService.GetTodo());
    }

    [HttpPost("remove")]
    public IActionResult RemoveTodo(string id)
    {
        try
        {
            _todoService.DeleteToDo(id);
            return Ok();
        }
        catch(Exception e)
        {
            return BadRequest();
        }
    }
    
}