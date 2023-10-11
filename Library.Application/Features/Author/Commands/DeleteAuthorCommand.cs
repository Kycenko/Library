using MediatR;

namespace Library.Application.Features.Author.Commands;

public class DeleteAuthorCommand : IRequest
{
    public Guid AuthorId { get; }
    public DeleteAuthorCommand(Guid authorId)
    {
        AuthorId = authorId;
    }
}