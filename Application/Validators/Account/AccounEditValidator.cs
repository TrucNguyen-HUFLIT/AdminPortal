using Application.Models.Account;
using FluentValidation;

namespace Application.Validators.Account
{
    public class AccounEditValidator : AbstractValidator<AccountEdit>
    {
        public AccounEditValidator()
        {
            RuleFor(actor => actor.AccId).NotEmpty();
            RuleFor(actor => actor.FirstName).NotEmpty();
            RuleFor(actor => actor.LastName).NotEmpty();
        }
    }
}
