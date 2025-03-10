using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Command.UserCommand;
using Test.Application.DTO;
using Test.Application.Query.UserQuery;

namespace TestProjectCQRS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetUserByName")]
        public async Task<IActionResult> GetUserByName(string user)
        {
            var data = await _mediator.Send(new GetUserByNameQuery() { Name = user });
            return Ok(data);
        }
        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUser(UserDTO userDTO)
        {
            var data = await _mediator.Send(new CreateUserCommand() { Model = userDTO});
            return Ok(data);
        }

    }
}
