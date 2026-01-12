namespace ContactManagementSyatem.data.model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Contact
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("userId")] 
    public string userId { get; set; } = null!;

    [BsonElement("FirstName")] 
    public string FirstName { get; set; } = null!;

    [BsonElement("LastName")] 
    public string LastName { get; set; } = null!;
   
    [BsonElement("PhoneNumber")]
    public string PhoneNumber { get; set; } = null!;
}