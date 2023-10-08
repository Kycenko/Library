using MediatR;

namespace Library.Application.User.Commands;

public class CreateUser : IRequest<Domain.Entities.User>, IRequest<IRequest>
{
    public string? Login { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
}