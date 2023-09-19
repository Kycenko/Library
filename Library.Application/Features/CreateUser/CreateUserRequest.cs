using Library.Application.Features.User;
using MediatR;

namespace Library.Application.Features.CreateUser;

public sealed record CreateUserRequest(string Login, string FirstName, string LastName, string Email,
	string PasswordHash) : IRequest<CreateUserResponse>;