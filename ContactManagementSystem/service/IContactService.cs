using ContactManagementSyatem.dto;
using ContactManagementSyatem.dto.response;

namespace ContactManagementSyatem.service;

public interface IContactService
{
   Task <AddContactResponse> AddContact(AddContactRequest request);
   Task<DelectUserResponse> DelectContact(FindUserRequest request);
   Task<UpdateContactResponse> UpdateContact(string userId, UpdateContactRequest request);
}