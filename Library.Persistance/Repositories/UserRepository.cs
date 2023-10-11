using Library.Application.Repositories;
using Library.Domain.Entities;
using Library.Infrastructure.Context;
using Library.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(LibraryDbContext context) : base(context)
		{
		}
		
		public Task<User?> GetByEmail(string email, CancellationToken cancellationToken) =>
			DbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
	}
}