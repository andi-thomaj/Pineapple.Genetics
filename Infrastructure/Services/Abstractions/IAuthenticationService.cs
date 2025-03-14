namespace Infrastructure.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<string> CreateToken(string email);
        string GenerateRefreshToken();
    }
}
