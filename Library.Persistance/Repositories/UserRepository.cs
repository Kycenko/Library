using Library.Application.Common.Exceptions;
using Library.Application.Repositories;
using Library.Domain.Common.Exceptions;
using Library.Domain.Entities;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		private readonly LibraryDbContext _dbContext;
		private readonly IUnitOfWork _unitOfWork;

		public UserRepository(LibraryDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
		{
			_dbContext = dbContext;
			_unitOfWork = unitOfWork;
		}

		public async Task CreateUserAsync(User newUser, CancellationToken cancellationToken)
		{
			try
			{
				await _dbContext.Set<User>().AddAsync(newUser, cancellationToken);
				await _unitOfWork.Save(cancellationToken);
			}
			catch (Exception ex)
			{
				throw new CreationException("Ошибка при создании пользователя!", ex);
			}
		}

		public async Task<IEnumerable<User>?> GetAllUsersAsync(CancellationToken cancellationToken)
		{
			try
			{
				return await _dbContext.Set<User>().ToListAsync(cancellationToken);
			}
			catch (Exception ex)
			{
				throw new NotFoundException("Ошибка при получении пользователей!", ex);
			}
		}

		public async Task<User?> GetUserAsync(Guid userId, CancellationToken cancellationToken)
		{
			try
			{
				return await _dbContext.Set<User>().FindAsync(new object[] { userId }, cancellationToken);
			}
			catch (Exception ex)
			{
				throw new NotFoundException("Ошибка при получении пользователя!", ex);
			}
		}

		public async Task<User?> UpdateUserAsync(Guid userId, User updatedUser, CancellationToken cancellationToken)
		{
			try
			{
				var existingUser = await _dbContext.Set<User>().FindAsync(new object[] { userId }, cancellationToken);

				if (existingUser == null)
				{
					throw new NotFoundException("Пользователь с таким Id не найден!");
				}

				existingUser.Login = updatedUser.Login;
				existingUser.FirstName = updatedUser.FirstName;
				existingUser.LastName = updatedUser.LastName;

				await _dbContext.SaveChangesAsync(cancellationToken);

				return existingUser;
			}
			catch (Exception ex)
			{
				throw new UpdateException("Ошибка при обновлении пользователя!", ex);
			}
		}

		public async Task<User?> DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
		{
			try
			{
				var userToDelete = await _dbContext.Set<User>().FindAsync(new object[] { userId }, cancellationToken);

				if (userToDelete == null)
				{
					throw new NotFoundException("Пользователь с таким Id не найден!");
				}

				_dbContext.Set<User>().Remove(userToDelete);
				await _dbContext.SaveChangesAsync(cancellationToken);

				return userToDelete;
			}
			catch (Exception ex)
			{
				throw new DeleteException("Ошибка при удалении пользователя!", ex);
			}
		}
	}
}