/*using Library.Application.User.Commands;
using Library.Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("[controller]")]
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
        public async Task<ActionResult<CreateUser>> Create([FromBody] CreateUser request,
            CancellationToken cancellationToken) => Ok(await _mediator.Send(request, cancellationToken));
    }
}*/