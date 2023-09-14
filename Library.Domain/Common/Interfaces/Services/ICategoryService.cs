using Library.Domain.Entities;

namespace Library.Domain.Common.Interfaces.Services;

public interface ICategoryService
{
	public Task CreateCategoryAsync(Guid categoryId);
	public Task<IEnumerable<Category>?> GetCategoriesAsync();
	public Task<Category?> GetCategoryAsync(Guid categoryId);
	public Task<Category?> UpdateCategoryAsync(Guid categoryId, Category newCategory);
	public Task<Category?> DeleteCategoryAsync(Guid categoryId);
}