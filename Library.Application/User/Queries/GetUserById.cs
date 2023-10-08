using MediatR;

namespace Library.Application.User.Queries;

public class GetUserById : IRequest<Domain.Entities.User>
{
    public Guid UserId { get; }

    public GetUserById(Guid userId)
    {
        UserId = userId;
    }
}