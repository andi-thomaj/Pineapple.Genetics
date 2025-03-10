using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.UserManagement.Repository
{
    public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        public async Task CreateUser(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
