using Library.Application.DTO_s.Author;
using MediatR;

namespace Library.Application.Features.Author.Queries;

public class GetAllAuthorsQuery : IRequest<List<AuthorDto>>
{
    
}