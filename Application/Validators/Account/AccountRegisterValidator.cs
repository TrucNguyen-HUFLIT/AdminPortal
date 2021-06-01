using Application.Models.Account;
using FluentValidation;

namespace Application.Validators.Account
{
    public class AccountRegisterValidator : AbstractValidator<AccountRegister>
    {
        public AccountRegisterValidator()
        {
            RuleFor(cus => cus.Email).NotEmpty();
            RuleFor(cus => cus.Password).NotEmpty();
            RuleFor(user => user.ConfirmPassword).NotEmpty()
                .Equal(user => user.Password).WithMessage("'Confirm Password' must be equal to 'Password'.");
            RuleFor(cus => cus.Password).MinimumLength(6).WithMessage("The entire string is longer than 6")
                .MaximumLength(20).WithMessage("The entire string is shorter than 20")
                .Matches(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])")
                .WithMessage("Password contains at least 1 uppercase letters, 1 lowercase letters and 1 numbers ");
        }
    }
}
