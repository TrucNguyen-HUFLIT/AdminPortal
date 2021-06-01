using Application.Models.Profile;
using FluentValidation;

namespace Application.Validators.Profile
{
    public class ProfileChangePasswordValidator : AbstractValidator<ProfileChangePassword>
    {
        public ProfileChangePasswordValidator()
        {
            RuleFor(user => user.OldPassword).NotEmpty();
            RuleFor(user => user.Password).NotEmpty();
            RuleFor(user => user.ConfirmPassword).NotEmpty()
                .Equal(user => user.Password).WithMessage("'Confirm Password' must be equal to 'Password'.");
            RuleFor(cus => cus.Password).MinimumLength(6).MaximumLength(20)
                .Matches(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,20}$")
                .WithMessage("Password contains at least 1 uppercase letters, 1 lowercase letters and 1 numbers, and the entire string is longer than 6");
        }
    }
}
