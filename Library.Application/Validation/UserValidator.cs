using FluentValidation;

namespace Library.Application.Validation;

public class UserValidator: AbstractValidator<Domain.Entities.User>
{
	public UserValidator()
	{
		RuleFor(u => u.Login).NotEmpty().WithMessage("Введите логин!");
	}
}