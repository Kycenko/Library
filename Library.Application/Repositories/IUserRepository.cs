using Library.Domain.Entities;

namespace Library.Application.Repositories;


public interface IUserRepository : IBaseRepository<User>
{
	public Task CreateUserAsync(User user);
	public Task<IEnumerable<User>?> GetAllUsersAsync();
	public Task<User?> GetUserAsync(Guid userId);
	public Task<User?> UpdateUserAsync(Guid userId, User updatedUser);
	public Task<User?> DeleteUserAsync(Guid userId);
}