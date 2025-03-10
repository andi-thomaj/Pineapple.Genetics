using FluentValidation;
using Infrastructure.EntityFramework.UserManagement.Repository;
using MediatR;

namespace WebApi.Controllers.UserManagement.Queries
{
    public class GetUserByEmailQuery
    {
        public class Query : IRequest<Result>
        {
            public required string Email { get; set; }
        }

        public class Result
        {
            public string FirstName { get; set; } = string.Empty;
            public string MiddleName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public required string UserName { get; set; }
            public required string Email { get; set; }
            public string Settings { get; set; } = string.Empty;
        }
    }

    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery.Query>
    {
        public GetUserByEmailQueryValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(async (email, _) => await userRepository.EmailExists(email))
                .WithMessage((command, email) => $"Email address: {email} doesn't exist.");
        }
    }

    public class GetUserByEmailQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByEmailQuery.Query, GetUserByEmailQuery.Result>
    {
        public async Task<GetUserByEmailQuery.Result> Handle(GetUserByEmailQuery.Query query,
            CancellationToken cancellationToken)
            => (await userRepository.GetUserByEmail(query.Email))!.GetUserByEmailQueryAsDto();
    }
}
