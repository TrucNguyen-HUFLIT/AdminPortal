using Application.Models.Profile;
using FluentValidation;

namespace Application.Validators.Profile
{
    public class AccountRequestValidator : AbstractValidator<AccountRequest>
    {
        public AccountRequestValidator()
        {
            RuleFor(actor => actor.FirstName).NotEmpty();
            RuleFor(actor => actor.LastName).NotEmpty();
            RuleFor(actor => actor.Password).NotEmpty();
            RuleFor(cus => cus.Password).MinimumLength(6).MaximumLength(20)
                 .Matches(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,20}$")
                 .WithMessage("Password contains at least 1 uppercase letters, 1 lowercase letters and 1 numbers, and the entire string is longer than 6");
        }
    }
}
