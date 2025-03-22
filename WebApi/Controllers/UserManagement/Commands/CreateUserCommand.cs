using Domain.UserManagement;
using FluentValidation;
using Infrastructure.EntityFramework.UserManagement.Configurations;
using Infrastructure.EntityFramework.UserManagement.Repository;
using MediatR;

namespace WebApi.Controllers.UserManagement.Commands
{
    public record CreateUserCommand(
        string? FirstName,
        string? MiddleName,
        string? LastName,
        string? Username,
        string Email,
        string Password,
        string? Settings) : IRequest<Unit>;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage((command, email) => $"Email: {email} is not a valid email address.")
                .MustAsync(async (email, _) => !await userRepository.EmailExists(email))
                .WithMessage((command, email) => $"Email address: {email} already exists.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(UserConfiguration.Settings.PasswordMinLength)
                .MaximumLength(UserConfiguration.Settings.PasswordMaxLength);
        }
    }

    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Unit>
    {
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Username = request.Username ?? request.Email,
                Email = request.Email,
                Password = request.Password,
                RoleId = (int)Roles.Basic,
                Settings = request.Settings ?? "{}"
            };

            await userRepository.CreateUser(user);

            return Unit.Value;
        }
    }
}
