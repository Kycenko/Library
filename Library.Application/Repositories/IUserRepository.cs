﻿using Library.Domain.Entities;

namespace Library.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
	Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
}