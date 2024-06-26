namespace AuthenticationAPI.Services
{
    public interface IAuthService
    {
        string Authenticate(string username, string password);
    }
}
