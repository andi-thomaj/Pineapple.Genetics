using Infrastructure.EntityFramework;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.UserManagement.Commands;
using WebApi.Controllers.UserManagement.Queries;

namespace WebApi.Controllers.UserManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator, ApplicationDbContext dbContext) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<GetUserByEmailQuery.Result>> GetUserByEmail([FromBody] GetUserByEmailQuery.Query query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
