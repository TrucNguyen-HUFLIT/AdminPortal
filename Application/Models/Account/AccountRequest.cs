using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Account
{
    public class AccountRequest
    {
        public int AccId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }

}
