using FluentValidation;
using RWBooks.Domain.Models;

namespace RWBooks.Domain.Validation
{
    public class AuthorInfoValidator : AbstractValidator<AuthorInfo>
    {
        public AuthorInfoValidator()
        {
            RuleFor(author => author.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(author => author.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must be between 1 and {MaxLength} characters.");
        }
    }
}
