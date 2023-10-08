using MediatR;

namespace Library.Application.User.Commands;

public class DeleteUser : IRequest<bool>
{
    public Domain.Entities.User UserId { get; }

    public DeleteUser(Domain.Entities.User userId)
    {
        UserId = userId;
    }
   
}