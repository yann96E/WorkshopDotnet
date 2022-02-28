using System.Collections.Immutable;
using MongoDB.Bson;
using MongoDB.Driver;
using TodoList.Database;
using TodoList.Models;

namespace TodoList.Services;

public class TodoListService
{
    private readonly IMongoCollection<Todo> _list;


    public TodoListService(DatabaseContext context)
    {
        _list = context.Database.GetCollection<Todo>("Todos");
    }

    public void AddToDo(Todo model)
    {
        _list.InsertOne(model);
    }

    public List<Todo> GetTodos() => _list.Find(x => true).ToList();

    public Todo GetById(string id) => _list.Find(e => e.Id == id).FirstOrDefault();
    
    public void Toggle(string id)
    {
        Todo todo = GetById(id);
        var filter = Builders<Todo>.Filter.Eq(nameof(Todo.Id), id);
        var update = Builders<Todo>.Update.Set(nameof(Todo.Active), !todo.Active);
        _list.UpdateOne(filter, update);
    }

        
    public void Edit(string id, string name)
    {
        Todo todo = GetById(id);
        var filter = Builders<Todo>.Filter.Eq(nameof(Todo.Id), id);
        var update = Builders<Todo>.Update.Set(nameof(Todo.Name), name);
        _list.UpdateOne(filter, update);
    }

    public void DeleteToDo(string id)
    {
        _list.DeleteOne(x => x.Id == id);
    }
}