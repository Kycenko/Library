using Library.Application.DTO_s.User;
using MediatR;

namespace Library.Application.User.Commands;

public class CreateUserCommand: IRequest<UserDto>
{
    public CreateUserDto User { get; set; }
    public CreateUserCommand(CreateUserDto user)
    {
        User = user;
    }

}