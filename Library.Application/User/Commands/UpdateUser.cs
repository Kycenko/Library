using Library.Domain.Enums;
using MediatR;

namespace Library.Application.User.Commands;

public class UpdateUser : IRequest<bool>
{
    public Domain.Entities.User NewUser { get; }

    public UpdateUser(Domain.Entities.User newUser)
    {
        NewUser = newUser;
    }
}