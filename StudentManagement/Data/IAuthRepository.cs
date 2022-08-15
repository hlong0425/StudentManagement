namespace StudentManagement.Data
{
    public interface IAuthRepository
    {
        Task<Response<int>> Register(User user, string password);

        Task<Response<string>> Login(string user, string password);

        Task<bool> UserExists(string username);
    }
}
