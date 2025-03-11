using Domain;

namespace Infrastructure.EntityFramework.UserManagement.Repository
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<bool> EmailExists(string email);
        Task<string?> GetRoleByUserId(int id);
    }
}
