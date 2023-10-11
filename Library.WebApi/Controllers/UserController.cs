using Library.Application.DTO_s.User;
using Library.Application.User.Commands;
using Library.Application.User.Queries;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserById(Guid userId) => Ok(await _mediator.Send(new GetUserByIdQuery(userId)));

        [HttpGet]
        public async Task<ActionResult> GetAllUsers() => Ok(await _mediator.Send(new GetAllUsersQuery()));

        [HttpPost]
        public async Task<ActionResult<CreateUserCommand>> CreateUser([FromBody] CreateUserCommand request,
            CancellationToken cancellationToken) => Ok(await _mediator.Send(request, cancellationToken));

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserDto user) =>
            Ok(await _mediator.Send(new UpdateUserCommand(userId, user)));

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(Guid userId) => Ok(_mediator.Send(new DeleteUserCommand(userId)));
    }
}