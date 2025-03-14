using Domain.UserManagement;

namespace Infrastructure.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<string> CreateToken(string email);
        Task<string> GenerateAndSaveRefreshTokenAsync(string email);
    }
}
