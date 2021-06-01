using System.ComponentModel.DataAnnotations;

namespace Application.Models.Profile
{
    public class ProfileChangePassword
    {
        [Display(Name = "Email")]
        public int AccId { get; set; }

        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
