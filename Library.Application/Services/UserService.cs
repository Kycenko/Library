using FluentValidation;
using Library.Domain.Common.Interfaces.Repositories;
using Library.Domain.Common.Interfaces.Services;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class UserService : IUserService
{
	private readonly IUserRepository _repository;

	public UserService(IUserRepository repository)
	{
		_repository = repository;
	}

	public async Task CreateUserAsync(User newUser)
	{
		await _repository.CreateUserAsync(newUser);
	}


	public async Task<IEnumerable<User>?> GetAllUsersAsync()
	{
		return await _repository.GetAllUsersAsync();
	}

	public async Task<User?> GetUserAsync(Guid UserId)
	{
		return await _repository.GetUserAsync(UserId);
	}

	public async Task<User?> UpdateUserAsync(Guid userId, User updatedUser)
	{
		return await _repository.UpdateUserAsync(userId, updatedUser);
	}

	public async Task<User?> DeleteUserAsync(Guid userId)
	{
		return await _repository.DeleteUserAsync(userId);
	}
}