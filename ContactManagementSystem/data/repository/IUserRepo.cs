using ContactManagementSyatem.data.model;
using ContactManagementSyatem.dto;

namespace ContactManagementSyatem.data.repository;

public interface IUserRepo
{
    Task<User>  AddUserAsync (User user);
    Task<User> FindUserByIdAsync (string id);
    Task<bool> DeleteByIdAsync (string id);
    Task<User> UpdateUserAsync (string userId, UpdateUserRequest request);
}