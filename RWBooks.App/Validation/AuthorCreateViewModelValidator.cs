using FluentValidation;
using RWBooks.App.Models;

namespace RWBooks.App.Validation
{
    public class AuthorCreateViewModelValidator : AbstractValidator<AuthorCreateViewModel>
    {
        public AuthorCreateViewModelValidator()
        {
            RuleFor(author => author.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must be between 1 and {MaxLength} characters.");
        }
    }
}
