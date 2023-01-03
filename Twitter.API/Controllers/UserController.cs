using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Application.Commands.UsersCommands.CreateUser;
using Twitter.Application.Commands.UsersCommands.DisableUserAccount;
using Twitter.Application.Commands.UsersCommands.UpdateUserAccount;
using Twitter.Application.Queries.UsersQueries.GetAllUsers;
using Twitter.Application.Queries.UsersQueries.GetUserById;

namespace Twitter.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();

            var users = await _mediator.Send(query);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("{id}/user")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("{id}/disable")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Disable(int id)
        {
            var command = new DisableUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
