namespace TodoList.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ListModel
{
    [BsonElement("name")]
        public string Name {get; set;} = String.Empty;
        
    [BsonElement("active")]
        public bool Active {get; set;} = true;
}