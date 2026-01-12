using ContactManagementSyatem.data.model;
using ContactManagementSyatem.dto;

namespace ContactManagementSyatem;

public class Mapper
{
    public static void Map(Contact contact, AddContactRequest addContactRequest)
    {
        contact.userId = addContactRequest.userId;
        contact.FirstName = addContactRequest.FirstName;
        contact.LastName = addContactRequest.LastName;
        contact.PhoneNumber = addContactRequest.PhoneNumber;
    }
}