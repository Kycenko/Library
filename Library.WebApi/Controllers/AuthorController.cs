using Library.Application.Features.Author.Commands;
using Library.Application.Features.Author.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult> GetAllAuthors() => Ok(await _mediator.Send(new GetAllAuthorsQuery()));
    
    [HttpPost]
    public async Task<ActionResult<CreateAuthorCommand>> CreateUser([FromBody] CreateAuthorCommand request,
        CancellationToken cancellationToken) => Ok(await _mediator.Send(request, cancellationToken));
}