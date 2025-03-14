﻿using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Domain.UserManagement;
using Infrastructure.EntityFramework.UserManagement.Repository;
using Infrastructure.Options;
using Infrastructure.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.Implementations
{
    public class AuthenticationService(IUserRepository userRepository, IOptions<JwtOptions> jwtOptions) : IAuthenticationService
    {
        private readonly JwtOptions _jwtOptions = jwtOptions.Value;
        public async Task<string> CreateToken(string email)
        {
            var user = await userRepository.GetUserByEmail(email);
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user!.Email),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Role, user.Role.Name)
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.Secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(10),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public async Task<string> GenerateAndSaveRefreshTokenAsync(string email)
        {
            var user = await userRepository.GetUserByEmail(email);
            var refreshToken = GenerateRefreshToken();
            user!.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await userRepository.UpdateUser(user);
            return refreshToken;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private async Task<User?> ValidateRefreshTokenAsync(int userId, string refreshToken)
        {
            var user = await userRepository.GetUserById(userId);
            if (user is null || user.RefreshToken != refreshToken
                             || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return null;
            }

            return user;
        }
    }
}
