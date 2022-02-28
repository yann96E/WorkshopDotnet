using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    private readonly TodoListService _todoListService;
    public TodoListController(TodoListService todoListService)
    {
        _todoListService = todoListService; 
    }

    public class AddTodoBody
    {
        public string Name { get; set; }
    }
    
    [HttpPost("add")]
    public IActionResult AddTodo([FromBody] AddTodoBody req)
    {
        Todo model = new Todo()
        {
            Name = req.Name
        };
        try
        {
            _todoListService.AddToDo(model);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet("get")]
    public ActionResult<List<Todo>> GetTodos()
    {
        return Ok(_todoListService.GetTodos());
    }
    
    public class TodoId
    {
        public string Id { get; set; }
    }

    [HttpPost("toggle")]
    public ActionResult Toggle([FromBody] TodoId req)
    {
        _todoListService.Toggle(req.Id);
        return Ok();
    }

    public class EditBody
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [HttpPost("edit")]
    public ActionResult Edit([FromBody] EditBody req)
    {
        _todoListService.Edit(req.Id, req.Name);
        return Ok();
    }

    [HttpPost("remove")]
    public IActionResult RemoveTodo([FromBody] TodoId req)
    {
        try
        {
            _todoListService.DeleteToDo(req.Id);
            return Ok();
        }
        catch(Exception e)
        {
            return BadRequest();
        }
    }
    
}