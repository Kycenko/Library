using Library.Application.DTO_s.Author;
using MediatR;

namespace Library.Application.Features.Author.Commands;

public class UpdateAuthorCommand : IRequest<UpdateAuthorDto>
{
    public Guid AuthorId { get; }
    public UpdateAuthorDto Author { get; }

    public UpdateAuthorCommand(Guid authorId, UpdateAuthorDto author)
    {
        AuthorId = authorId;
        Author = author;
    }
}