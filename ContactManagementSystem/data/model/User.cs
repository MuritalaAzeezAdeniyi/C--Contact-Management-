using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactManagementSyatem.data.model;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string  Id { get; set; }
    
    [BsonElement("FirstName")]
    public string FirstName { get; set; } = null!;
   
    [BsonElement("LastName")]
    public string LastName { get; set; } = null!;
   
    [BsonElement("Email")]
    public string Email { get; set; } = null!;
}