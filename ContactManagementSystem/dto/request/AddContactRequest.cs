namespace ContactManagementSyatem.dto;

public class AddContactRequest
{
    public string userId { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}