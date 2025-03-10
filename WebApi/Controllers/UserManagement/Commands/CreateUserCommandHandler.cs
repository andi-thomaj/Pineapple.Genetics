using Infrastructure.EntityFramework.UserManagement.Repository;
using MediatR;

namespace WebApi.Controllers.UserManagement.Commands
{
    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Unit>
    {
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
