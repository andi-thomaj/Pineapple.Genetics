using Domain.UserManagement;
using Domain.UserManagement.Configurations;
using FluentValidation;
using Infrastructure.EntityFramework.UserManagement.Repository;
using Infrastructure.Services.Abstractions;
using MediatR;

namespace WebApi.Controllers.UserManagement.Queries
{
    public record RegisterQuery
    {
        public record Query(
            string Email,
            string Password,
            string? Username,
            string? FirstName,
            string? MiddleName,
            string? LastName,
            string? Settings) : IRequest<Result>;

        public record Result(
            string FirstName,
            string MiddleName,
            string LastName,
            string UserName,
            string Email,
            string Settings,
            string Jwt,
            string RefreshToken);
    }

    public class RegisterQueryValidator : AbstractValidator<RegisterQuery.Query>
    {
        public RegisterQueryValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(async (email, _) => await userRepository.EmailExists(email))
                .WithMessage((command, email) => $"Email address: {email} already exists.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(UserConfiguration.Settings.PasswordMinLength)
                .MaximumLength(UserConfiguration.Settings.PasswordMaxLength);
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(UserConfiguration.Settings.UsernameMinLength)
                .MaximumLength(UserConfiguration.Settings.UsernameMaxLength)
                .MustAsync(async (username, _) => await userRepository.UsernameExists(username))
                .WithMessage((command, username) => $"Username: {username} already exists.");
        }
    }

    public class RegisterQueryHandler(IAuthenticationService authenticationService
        , IUserRepository userRepository) : IRequestHandler<RegisterQuery.Query, RegisterQuery.Result>
    {
        public async Task<RegisterQuery.Result> Handle(RegisterQuery.Query query, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = query.Username ?? query.Email,
                Email = query.Email,
                Password = query.Password,
                FirstName = query.FirstName,
                MiddleName = query.MiddleName,
                LastName = query.LastName,
                Settings = query.Settings ?? string.Empty,
                RoleId = (int)Roles.Basic
            };
            await userRepository.CreateUser(user);
            var jwt = await authenticationService.CreateToken(user.Email);
            var refreshToken = await authenticationService.GenerateAndSaveRefreshTokenAsync(user.Email);

            return new RegisterQuery.Result(
                user.FirstName ?? string.Empty,
                user.MiddleName ?? string.Empty,
                user.LastName ?? string.Empty,
                user.Username,
                user.Email,
                user.Settings,
                jwt,
                refreshToken);
        }
    }
}
