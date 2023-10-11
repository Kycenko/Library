using Library.Application.DTO_s.User;
using MediatR;

namespace Library.Application.Features.User.Commands
{
    public class UpdateUserCommand: IRequest<UserDto>
    {
        public Guid UserId { get; }
        public UpdateUserDto User { get; }
        public UpdateUserCommand(Guid userId, UpdateUserDto user)
        {
            UserId = userId;
            User = user;
        }
    }
}
