using Library.Application.DTO_s.Author;
using MediatR;

namespace Library.Application.Features.Author.Queries;

public class GetAuthorQuery : IRequest<AuthorDto>
{
    public Guid AuthorId { get; }

    public GetAuthorQuery(Guid authorId)
    {
        AuthorId = authorId;
    }
}