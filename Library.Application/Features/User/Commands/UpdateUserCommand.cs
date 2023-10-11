using Library.Application.DTO_s.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.User.Commands
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
