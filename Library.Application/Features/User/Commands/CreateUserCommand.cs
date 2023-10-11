using Library.Application.DTO_s.User;
using MediatR;

namespace Library.Application.Features.User.Commands;

public class CreateUserCommand: IRequest<UserDto>
{
    public CreateUserDto User { get; }
    public CreateUserCommand(CreateUserDto user)
    {
        User = user;
    }

}