using Application.Models.Account;
using FluentValidation;

namespace Application.Validators.Account
{
    public class AccountCreateValidator : AbstractValidator<AccountCreate>
    {
        public AccountCreateValidator()
        {
            RuleFor(cus => cus.Email).EmailAddress().NotEmpty();
            RuleFor(cus => cus.Password).NotEmpty();
            RuleFor(cus => cus.Password).MinimumLength(6).MaximumLength(20)
                 .Matches(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,20}$")
                 .WithMessage("Password contains at least 1 uppercase letters, 1 lowercase letters and 1 numbers, and the entire string is longer than 6");
            RuleFor(cus => cus.FirstName).NotEmpty();
            RuleFor(cus => cus.LastName).NotEmpty();
            RuleFor(cus => cus.RoleId).NotEmpty();
        }

    }
}
