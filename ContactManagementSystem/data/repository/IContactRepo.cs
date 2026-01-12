using ContactManagementSyatem.data.model;
using ContactManagementSyatem.dto;

namespace ContactManagementSyatem.data.repository;

public interface IContactRepo
{
    Task<Contact> AddContactAsync(Contact contact);
    Task<List<Contact>> FindContactByUserIdAsync(string userId);
    Task<List<Contact>> FindContactByUserNameAsync(string userName);
    Task<bool> DeleteContactByUserIdAndContactIdAsync(string id, string userId);
    Task<bool> FindIfContactExistsForThisUserAsync(string phoneNumber, string userId);
    Task<Contact> UpdateContactAsync(string userId, UpdateContactRequest request);
}