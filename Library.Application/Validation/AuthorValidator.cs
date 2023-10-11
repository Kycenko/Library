using FluentValidation;
using Library.Domain.Entities;

namespace Library.Application.Validation;

public class AuthorValidator :  AbstractValidator<Author>
{
    public AuthorValidator()
    {
        
    }
}