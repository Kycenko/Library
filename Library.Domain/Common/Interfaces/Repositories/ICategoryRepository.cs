using Library.Domain.Entities;

namespace Library.Domain.Common.Interfaces.Repositories;

public interface ICategoryRepository
{
	public Task CreateCategoryAsync(Category category);
	public Task<IEnumerable<Category>?> GetAllCategoriesAsync();
	public Task<Category?> GetCategoryAsync(Guid categoryId);
	public Task<Category?> UpdateCategoryAsync(Guid categoryId, Category updatedCategory);
	public Task<Category?> DeleteCategoryAsync(Guid categoryId);
}