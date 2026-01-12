using ContactManagementSyatem.data.model;
using ContactManagementSyatem.dto;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ContactManagementSyatem.data.repository;

public class ContactRepo : IContactRepo
{
    private readonly IMongoCollection<Contact> _contacts;

    public ContactRepo(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("ContactManagementSystem");
        _contacts = database.GetCollection<Contact>("Contacts");
    } 
     
    public async Task<Contact> AddContactAsync(Contact contact)
    {
        await _contacts.InsertOneAsync(contact);
        return contact;
    }

    public async Task<List<Contact>> FindContactByUserIdAsync(string userId)
    {
        return await _contacts
            .Find(contact => contact.userId.Equals(userId))
            .ToListAsync();
    }

    public Task<List<Contact>> FindContactByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteContactByUserIdAndContactIdAsync(string id, string userId)
    {
        var result = await _contacts.DeleteOneAsync(contact => contact.userId.Equals(userId));
        
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<bool> FindIfContactExistsForThisUserAsync(string phoneNumber, string userId)
    {
         return await _contacts
             .Find(contact => contact.userId.Equals(userId) && contact.PhoneNumber.Equals(phoneNumber))
             .AnyAsync();
    }

    public async Task<Contact> UpdateContactAsync(string userId, UpdateContactRequest request)
    {
        var filter = Builders<Contact>.Filter.Eq(c => c.userId, userId);
        var update = Builders<Contact>.Update
            .Set(c => c.PhoneNumber, request.PhoneNumber)
            .Set(c => c.FirstName, request.FirstName)
            .Set(c => c.LastName, request.LastName);
  
        var option = new FindOneAndUpdateOptions<Contact>
        {
            ReturnDocument = ReturnDocument.After,
        };
       
        return await _contacts.FindOneAndUpdateAsync(filter, update, option);
    }
    
}