using FluentValidation;
using Infrastructure.EntityFramework.UserManagement.Repository;
using Infrastructure.Services.Abstractions;
using MediatR;

namespace WebApi.Controllers.UserManagement.Queries
{
    public record LoginQuery
    {
        public record Query(string Email, string Password) : IRequest<Result>;

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

    public class LoginQueryValidator : AbstractValidator<LoginQuery.Query>
    {
        public LoginQueryValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MustAsync(async (email, _) => await userRepository.EmailExists(email))
                .WithMessage((command, email) => $"Email address: {email} doesn't exist.");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20)
                .MustAsync(async (query, _, _) => await userRepository.PasswordIsCorrect(query.Email, query.Password))
                .WithMessage("Password is incorrect. Please try again.");
        }
    }

    public class LoginQueryHandler(IAuthenticationService authenticationService
        , IUserRepository userRepository) : IRequestHandler<LoginQuery.Query, LoginQuery.Result>
    {
        public async Task<LoginQuery.Result> Handle(LoginQuery.Query request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByEmail(request.Email);
            var jwt = await authenticationService.CreateToken(user!.Email);
            var refreshToken = await authenticationService.GenerateAndSaveRefreshTokenAsync(user.Email);

            return new LoginQuery.Result(
                 user.FirstName ?? string.Empty
                ,user.MiddleName ?? string.Empty
                ,user.LastName ?? string.Empty
                ,user.Username
                ,user.Email
                ,user.Settings
                ,jwt
                ,refreshToken);
        }
    }
}
