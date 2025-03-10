using MediatR;

namespace WebApi.Controllers.UserManagement.Commands
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Settings { get; set; }
    }
}
