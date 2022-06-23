using FluentValidation;
using Solor_BackEnd.Models;

namespace Solor_BackEnd.Validations
{
    public class TeamValidation:AbstractValidator<Team>
    {
        public TeamValidation()
        {
            RuleFor(t => t.Title).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(t => t.Description).NotEmpty().MaximumLength(20);
            RuleFor(t => t.Position).NotNull().NotEmpty();
        }
    }
}
