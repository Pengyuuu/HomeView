namespace Services.Contracts
{
    public interface IRegistrationService
    {
        bool CreateUser(string email, string dob, string pw);
    }
}