using Library.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult> GetUserById(Guid userId)
		{
			var result = await _mediator.Send(new GetUserQuery(userId));
			return Ok(result);
		}

		[HttpGet]
		public async Task<ActionResult> GetAllUsers()
		{
			var result = await _mediator.Send(new GetAllUsersQuery());
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<CreateUserResponse>> Create([FromBody] CreateUserRequest request,
			CancellationToken cancellationToken)
		{
			var response = await _mediator.Send(request, cancellationToken);
			return Ok(response);
		}
	}
}