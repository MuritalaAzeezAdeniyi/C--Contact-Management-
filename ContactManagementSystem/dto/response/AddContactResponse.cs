namespace ContactManagementSyatem.dto.response;

public class AddContactResponse
{
    private string userId;

    private string firstName;

    private string lastName;
    
    private string phoneNumber;

    public string UserId
    {
        get =>  userId;
        set => userId = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string FirstName
    {
        get => firstName;
        set => firstName = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public string LastName
    {
        get => lastName;
        set => lastName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string PhoneNumber
    {
        get => phoneNumber;
        set => phoneNumber = value ?? throw new ArgumentNullException(nameof(value));
    }
}