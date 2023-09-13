using Library.Domain.Common.Exceptions;
using Library.Domain.Common.Interfaces.Repositories;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
	private readonly LibraryDbContext _dbContext;

	public UserRepository(LibraryDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	
	public async Task CreateUserAsync(User newUser)
	{
		try
		{
			await _dbContext.Users.AddAsync(newUser);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new CreationException("Ошибка при создании пользователя!", ex);
		}
	}

	public async Task<IEnumerable<User>?> GetAllUsersAsync()
	{
		try
		{
			return await _dbContext.Users.ToListAsync();
		}
		catch (Exception ex)
		{
			throw new NotFoundException("Ошибка при получении пользователей!", ex);
		}
	}

	public async Task<User?> GetUserAsync(Guid userId)
	{
		try
		{
			return await _dbContext.Users.FindAsync(userId);
		}
		catch (Exception ex)
		{
			throw new NotFoundException("Ошибка при получении пользователя!", ex);
		}
	}

	public async Task<User?> UpdateUserAsync(Guid userId, User updatedUser)
	{
		try
		{
			var existingUser = await _dbContext.Users.FindAsync(userId);

			if (existingUser == null)
			{
				throw new NotFoundException("Пользователь с таким Id не найден!");
			}

			existingUser.UserName = updatedUser.UserName;
			existingUser.FirstName = updatedUser.FirstName;
			existingUser.LastName = updatedUser.LastName;

			await _dbContext.SaveChangesAsync();

			return existingUser;
		}
		catch (Exception ex)
		{
			throw new UpdateException("Ошибка при обновлении пользователя!", ex);
		}
	}

	public async Task<User?> DeleteUserAsync(Guid userId)
	{
		try
		{
			var userToDelete = await _dbContext.Users.FindAsync(userId);

			if (userToDelete == null)
			{
				throw new NotFoundException("Пользователь с таким Id не найден!");
			}

			_dbContext.Users.Remove(userToDelete);
			await _dbContext.SaveChangesAsync();

			return userToDelete;
		}
		catch (Exception ex)
		{
			throw new DeleteException("Ошибка при удалении пользователя!", ex);
		}
	}
}