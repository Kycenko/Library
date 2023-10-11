using Library.Application.DTO_s.Author;
using Library.Application.DTO_s.User;
using MediatR;

namespace Library.Application.Features.Author.Commands;

public class CreateAuthorCommand : IRequest<AuthorDto>
{
    public CreateAuthorDto Author { get; }

    public CreateAuthorCommand(CreateAuthorDto author)
    {
        Author = author;
    }
}