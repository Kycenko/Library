using MediatR;

namespace Library.Application.Queries.User;

public class GetAllUsersQuery : IRequest<IEnumerable<GetUserResponse>>
{
	
}