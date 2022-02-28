namespace TodoList.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Todo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id_ { get; set; }

    [BsonElement("id")]
    public string Id
    {
        get
        {
            return Id_.ToString();
        }
    }

    [BsonElement("name")]
    public string Name {get; set;} = String.Empty;
        
    [BsonElement("active")]
    public bool Active {get; set;} = true;
}