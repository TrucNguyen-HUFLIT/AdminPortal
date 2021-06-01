using Application.Models.Account;
using FluentValidation;

namespace Application.Validators.Account
{
    public class AccountLoginValidator : AbstractValidator<AccountLogin>
    {
        public AccountLoginValidator()
        {
            RuleFor(cus => cus.Email).NotEmpty();
            RuleFor(cus => cus.Password).NotEmpty();
        }
    }
}
