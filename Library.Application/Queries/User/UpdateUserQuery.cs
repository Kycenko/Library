using MediatR;

namespace Library.Application.Queries.User;

public class UpdateUserQuery : IRequest<UpdateUserResponse>
{
	public Guid UserId { get; }

	public UpdateUserQuery(Guid userId)
	{
		UserId = userId;
	}
}