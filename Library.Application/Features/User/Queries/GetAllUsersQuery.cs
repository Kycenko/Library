using Library.Application.DTO_s.User;
using MediatR;

namespace Library.Application.Features.User.Queries;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{

}