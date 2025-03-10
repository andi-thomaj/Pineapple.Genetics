using Domain;
using WebApi.Controllers.UserManagement.Queries;

namespace WebApi.Controllers
{
    public static class DtoExtensions
    {
        public static GetUserByEmailQuery.Result GetUserByEmailQueryAsDto(this User user)
            => new()
            {
                FirstName = user.FirstName ?? string.Empty,
                MiddleName = user.MiddleName ?? string.Empty,
                LastName = user.LastName ?? string.Empty,
                UserName = user.Username,
                Email = user.Email,
                Settings = user.Settings
            };
    }
}
