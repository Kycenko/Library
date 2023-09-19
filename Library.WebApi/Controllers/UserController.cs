using Library.Application.Features.CreateUser;
using Library.Application.Features.User;
using Library.Application.Repositories;
using Library.Domain.Entities;
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

		[HttpPost]
		public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request,
			CancellationToken cancellationToken)
		{
			var response = await _mediator.Send(request, cancellationToken);
			return Ok(response);
		}
	}
}