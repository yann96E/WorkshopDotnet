using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TodoList.Database;
public class DatabaseContext
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;

    public DatabaseContext(IOptions<DatabaseSettings> dbOptions)
    {
        Console.WriteLine("test");
        var settings = dbOptions.Value;
        Console.WriteLine(settings.ConnectionString);
        _client = new MongoClient(settings.ConnectionString);
        _database = _client.GetDatabase(settings.DatabaseName);
    }

    public IMongoClient Client => _client;

    public IMongoDatabase Database => _database;
}