using MediatR;
using System.Text.Json;

namespace Library.Application.User.Commands
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