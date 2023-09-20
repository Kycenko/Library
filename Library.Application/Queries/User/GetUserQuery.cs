using MediatR;

namespace Library.Application.Queries.User;

public class GetUserQuery : IRequest<GetUserResponse>
{
	public Guid UserId { get; }

	public GetUserQuery(Guid userId)
	{
		UserId = userId;
	}
}