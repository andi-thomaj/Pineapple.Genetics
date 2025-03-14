using Domain.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.UserManagement.Repository
{
    public sealed class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        public async Task CreateUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserById(int id)
         => await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User?> GetUserByEmail(string email)
         => await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<bool> EmailExists(string email)
         => await dbContext.Users.AnyAsync(x => x.Email == email);

        public async Task<string?> GetRoleByUserId(int id)
         => await dbContext.Users.Where(x => x.Id == id).Select(x => x.Role.Name).FirstOrDefaultAsync();

        public async Task<bool> PasswordIsCorrect(string email, string password)
         => await dbContext.Users.AnyAsync(x => x.Email == email && x.Password == password);

        public async Task<bool> UsernameExists(string username)
         => await dbContext.Users.AnyAsync(x => x.Username == username);
    }
}
