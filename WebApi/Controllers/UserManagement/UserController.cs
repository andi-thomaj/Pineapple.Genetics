using Domain;
using Infrastructure.EntityFramework;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.UserManagement
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IMediator mediator, ApplicationDbContext dbContext) : ControllerBase
    {
        public async Task<IActionResult> CreateUser(User user)
        {
            // await mediator.Send(new CreateUserCommand());
            return Ok();
        }
    }
}
