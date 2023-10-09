using Library.Application.DTO_s.User;
using MediatR;

namespace Library.Application.User.Queries;

public class GetUserByIdQuery: IRequest<UserDto>
{
	public Guid UserId { get; }

    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
}