using Library.Domain.Common.Interfaces.Services;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class CategoryService : ICategoryService
{
	public async Task CreateCategoryAsync(Guid categoryId)
	{
		await CreateCategoryAsync(categoryId);
	}

	public async Task<IEnumerable<Category>?> GetCategoriesAsync()
	{
		return await GetCategoriesAsync();
	}

	public async Task<Category?> GetCategoryAsync(Guid categoryId)
	{
		return await GetCategoryAsync(categoryId);
	}

	public async Task<Category?> UpdateCategoryAsync(Guid categoryId, Category newCategory)
	{
	 return	await UpdateCategoryAsync(categoryId, newCategory);
	}

	public async Task<Category?> DeleteCategoryAsync(Guid categoryId)
	{
		return await DeleteCategoryAsync(categoryId);
	}
}