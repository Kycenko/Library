using Library.Domain.Entities;

namespace Library.Domain.Common.Interfaces.Services;

public interface IUserService
{
	public Task CreateUserAsync(User user, CancellationToken cancellationToken);

	public Task<IEnumerable<User>?> GetAllUsersAsync(CancellationToken cancellationToken);
	public Task<User?> GetUserAsync(Guid userId, CancellationToken cancellationToken);
	
	public Task<User?> UpdateUserAsync(Guid userId, User updatedUser, CancellationToken cancellationToken);
	
	public Task<User?> DeleteUserAsync(Guid userId, CancellationToken cancellationToken);
}