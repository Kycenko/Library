namespace Library.Application.Features.User;

using FluentValidation;
using Library.Domain.Entities;

public class UserValidator : AbstractValidator<User>
{
	public UserValidator()
	{
		RuleFor(user => user.UserName)
			.NotEmpty().WithMessage("UserName is required")
			.MaximumLength(15).WithMessage("UserName cannot exceed 50 characters");

		// RuleFor(user => user.FirstName)
		// 	.NotEmpty().WithMessage("FirstName is required")
		// 	.MaximumLength(20).WithMessage("FirstName cannot exceed 50 characters");
		//
		// RuleFor(user => user.LastName)
		// 	.NotEmpty().WithMessage("LastName is required")
		// 	.MaximumLength(20).WithMessage("LastName cannot exceed 50 characters");

		RuleFor(user => user.PasswordHash)
			.NotEmpty().WithMessage("PasswordHash is required")
			.MinimumLength(8).WithMessage("Password must be at least 8 characters long")
			.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
			.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
			.Matches("[0-9]").WithMessage("Password must contain at least one digit");
			//.Matches("[!@#$%^&*]").WithMessage("Password must contain at least one special character (!@#$%^&*)");


		// RuleFor(user => user.Email)
		// 	.NotEmpty().WithMessage("Email is required")
		// 	.EmailAddress().WithMessage("Email is not valid")
		// 	.MaximumLength(50).WithMessage("Email cannot exceed 100 characters");

		RuleFor(user => user.Role)
			.IsInEnum().WithMessage("Role is not valid");
        
	}
}