using Library.Application.Repositories;
using Library.Domain.Entities;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Library.Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(LibraryDbContext context) : base(context)
		{
		}

		//public new async Task Create(User entity) => await DbContext.AddAsync(entity);

		public Task<User?> GetByEmail(string email, CancellationToken cancellationToken) =>
			DbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
	}
}