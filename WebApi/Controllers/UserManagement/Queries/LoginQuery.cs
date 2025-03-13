using FluentValidation;
using Infrastructure.EntityFramework.UserManagement.Repository;
using Infrastructure.Services.Abstractions;
using MediatR;

namespace WebApi.Controllers.UserManagement.Queries
{
    public class LoginQuery
    {
        public class Query : IRequest<Result>
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        public class Result
        {
            public string FirstName { get; set; } = string.Empty;
            public string MiddleName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public required string UserName { get; set; }
            public required string Email { get; set; }
            public string Settings { get; set; } = string.Empty;
            public required string Jwt { get; set; }
        }
    }

    public class LoginQueryValidator : AbstractValidator<LoginQuery.Query>
    {
        public LoginQueryValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(async (email, _) => await userRepository.EmailExists(email))
                .WithMessage((command, email) => $"Email address: {email} doesn't exist.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20)
                .MustAsync(async (query, _, _) => await userRepository.PasswordIsCorrect(query.Email, query.Password))
                .WithMessage("Password or email is incorrect. Please try again.");
        }
    }

    // public class LoginQueryHandler(IAuthenticationService authenticationService) : IRequestHandler<LoginQuery.Query, LoginQuery.Result>
    // {
    //     public Task<LoginQuery.Result> Handle(LoginQuery.Query request, CancellationToken cancellationToken)
    //     {
    //         var user = 
    //     }
    // }
}
