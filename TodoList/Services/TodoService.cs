using MongoDB.Bson;
using MongoDB.Driver;
using TodoList.Database;
using TodoList.Models;

namespace TodoList;
public class TodoList
{
    private readonly IMongoCollection<ListModel> _list;


    public TodoList(DatabaseContext context)
    {
        _list = context.Database.GetCollection<ListModel>("list");
    }

    public void AddToDo(ListModel model)
    {
        _list.InsertOne(model);
    }

    public List<ListModel> GetTodo() => _list.Find(x => true).ToList();

    public void DeleteToDo(string id)
    {
        _list.DeleteOne(x => x.Id == id);
    }
}