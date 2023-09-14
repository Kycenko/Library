using FluentValidation;

namespace Library.Application.Features.Category;

using Library.Domain.Entities;

public class CategoryValidator : AbstractValidator<Category>
{
	public CategoryValidator()
	{
		RuleFor(category => category.CategoryName).NotEmpty().WithMessage("CategoryName is required")
			.MaximumLength(15).WithMessage("CategoryName cannot exceed 50 characters");
	}
}