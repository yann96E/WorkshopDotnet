using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    [HttpPost("add")]
    public void addTodo()
    {
        
    }
    
}