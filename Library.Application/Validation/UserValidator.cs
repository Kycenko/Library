using FluentValidation;

namespace Library.Application.Validation;

public class UserValidator : AbstractValidator<Domain.Entities.User>
{
    public UserValidator()
    {
        RuleFor(x => x.Login).NotEmpty();
        /* RuleFor(x => x.FirstName).NotEmpty();
         RuleFor(x => x.LastName).NotEmpty();
         RuleFor(x => x.Email).NotEmpty().EmailAddress();
         RuleFor(x => x.PasswordHash).NotEmpty().MinimumLength(6);
         RuleFor(x => x.Role).NotEmpty();*/
    }
}