using Library.Domain.Common.Exceptions;
using Library.Domain.Common.Interfaces.Repositories;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
	private readonly LibraryDbContext _dbContext;

	public CategoryRepository(LibraryDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task CreateCategoryAsync(Category category)
	{
		try
		{
			await _dbContext.Categories.AddAsync(category);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new CreationException("Ошибка при создании категории!", ex);
		}
	}

	public async Task<IEnumerable<Category>?> GetAllCategoriesAsync()
	{
		try
		{
			return await _dbContext.Categories.ToListAsync();
		}
		catch (Exception ex)
		{
			throw new NotFoundException("Ошибка при получении категорий!", ex);
		}
	}

	public async Task<Category?> GetCategoryAsync(Guid categoryId)
	{
		try
		{
			return await _dbContext.Categories.FindAsync(categoryId);
		}
		catch (Exception ex)
		{
			throw new NotFoundException("Ошибка при получении категории!", ex);
		}
	}


	public async Task<Category?> UpdateCategoryAsync(Guid categoryId, Category updatedCategory)
	{
		try
		{
			var existingCategory = await _dbContext.Categories.FindAsync(categoryId);
			if (existingCategory == null)
			{
				throw new NotFoundException("Категория с таким Id не найдена!");
			}

			existingCategory.CategoryName = updatedCategory.CategoryName;

			await _dbContext.SaveChangesAsync();
			return existingCategory;
		}
		catch (Exception ex)
		{
			throw new UpdateException("Ошибка при обновлении категории!", ex);
		}
	}

	public async Task<Category?> DeleteCategoryAsync(Guid categoryId)
	{
		try
		{
			var categoryToDelete = await _dbContext.Categories.FindAsync(categoryId);
			if (categoryToDelete == null)
			{
				throw new NotFoundException("Категория с таким Id не найдена!");
			}

			_dbContext.Categories.Remove(categoryToDelete);
			await _dbContext.SaveChangesAsync();
			return categoryToDelete;
		}
		catch (Exception ex)
		{
			throw new DeleteException("Ошибка при удалении категории!", ex);
		}
	}
}