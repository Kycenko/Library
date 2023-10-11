using Library.Application.DTO_s.User;
using MediatR;

namespace Library.Application.User.Queries;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{

}