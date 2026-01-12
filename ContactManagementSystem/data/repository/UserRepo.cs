using ContactManagementSyatem.data.model;
using ContactManagementSyatem.dto;

namespace ContactManagementSyatem.data.repository;
using MongoDB.Driver;
public class UserRepo : IUserRepo

{
   private readonly IMongoCollection<User> _users;

   public UserRepo(MongoClient mongoClient)
   {
       var database = mongoClient.GetDatabase("ContactManagementSystem");
       _users = database.GetCollection<User>("Users");
   }
    
    public async Task<User> AddUserAsync(User user)
    {
        await _users.InsertOneAsync(user);
        return user;
    }

    public async Task<User> FindUserByIdAsync(string id)
    {
       return await _users.
           Find(userId => userId.Id.Equals(id)).
           FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteByIdAsync(string id)
    {
        var result = await  _users.DeleteOneAsync(user => user.Id.Equals(id));
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<User> UpdateUserAsync(string userId, UpdateUserRequest request)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
        var update = Builders<User>.Update
            .Set(u => u.FirstName, request.FirstName)
            .Set(u => u.LastName, request.LastName)
            .Set(u => u.Email, request.Email);

        var option = new FindOneAndUpdateOptions<User>
        {
          ReturnDocument = ReturnDocument.After
        };
        
        return await _users.FindOneAndUpdateAsync(filter, update, option);
    }
}