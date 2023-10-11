using MediatR;

namespace Library.Application.Features.User.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid UserId { get; }

        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}