using Domain.UserManagement;

namespace Infrastructure.EntityFramework.UserManagement.Repository
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<bool> EmailExists(string email);
        Task<string?> GetRoleByUserId(int id);
        Task<bool> PasswordIsCorrect(string email, string password);
        Task<bool> UsernameExists(string username);
        Task UpdateUser(User user);
        Task<User?> LoginUser(string email, string password);
    }
}
