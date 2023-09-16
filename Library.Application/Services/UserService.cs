using FluentValidation;
using Library.Application.Repositories;
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

	public async Task CreateUserAsync(User newUser, CancellationToken cancellationToken)
	{
		await _repository.CreateUserAsync(newUser, cancellationToken);
	}


	public async Task<IEnumerable<User>?> GetAllUsersAsync(CancellationToken cancellationToken)
	{
		return await _repository.GetAllUsersAsync(cancellationToken);
	}

	public async Task<User?> GetUserAsync(Guid userId, CancellationToken cancellationToken)
	{
		return await _repository.GetUserAsync(userId, cancellationToken);
	}

	public async Task<User?> UpdateUserAsync(Guid userId, User updatedUser, CancellationToken cancellationToken)
	{
		return await _repository.UpdateUserAsync(userId, updatedUser, cancellationToken);
	}

	public async Task<User?> DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
	{
		return await _repository.DeleteUserAsync(userId, cancellationToken);
	}
}