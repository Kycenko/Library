﻿using MediatR;

namespace Library.Application.Queries.User;

public sealed record CreateUserRequest(string Login, string FirstName, string LastName, string Email,
	string PasswordHash) : IRequest<CreateUserResponse>;