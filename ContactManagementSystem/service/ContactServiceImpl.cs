using ContactManagementSyatem.data.model;
using ContactManagementSyatem.data.repository;
using ContactManagementSyatem.dto;
using ContactManagementSyatem.dto.response;

namespace ContactManagementSyatem.service;

public class ContactServiceImpl : IContactService
{
    private readonly IContactRepo _contactRepo;

    public ContactServiceImpl(IContactRepo contactRepo)
    {
       _contactRepo = contactRepo;
    }
        
    public async Task <AddContactResponse> AddContact(AddContactRequest request)
    {
       Contact contact = new  Contact();
       bool check = await _contactRepo.FindIfContactExistsForThisUserAsync(request.PhoneNumber,request.userId);
        if(check) throw new ArgumentException("Phone number already exists");
        Mapper.Map(contact, request);
        await _contactRepo.AddContactAsync(contact);
        AddContactResponse response = new AddContactResponse();
        response.FirstName = contact.FirstName;
        response.LastName = contact.LastName;
        response.PhoneNumber = contact.PhoneNumber;
        response.UserId = contact.userId;
        return response;
    }

    public async Task<DelectUserResponse> DelectContact(FindUserRequest request)
    {
        var result = _contactRepo.DeleteContactByUserIdAndContactIdAsync(request.id, request.userId);
        DelectUserResponse response = new DelectUserResponse();
        if (result.Result)
        {
            response.message = "Successfully deleted contact";
        }
        return response;
    }

    public async Task<UpdateContactResponse> UpdateContact(string userId, UpdateContactRequest request)
    {
        List<Contact> contacts = await _contactRepo.FindContactByUserIdAsync(userId);
        if (contacts == null)
        {
            throw new ArgumentException("Contact not found");
        }
        await _contactRepo.UpdateContactAsync(userId, request);
        
        return new UpdateContactResponse
        {
         FirstName = request.FirstName,
         LastName = request.LastName,
         PhoneNumber = request.PhoneNumber,
         Message = "Contact updated successfully"
        };
        
    }
    
   
    
  


}