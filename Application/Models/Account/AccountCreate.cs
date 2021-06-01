using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Account
{
    public class AccountCreate
    {
        [Display(Name = "ID Account")]
        public int AccId { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Avatar")]
        public string Avatar { get; set; }

        [Display(Name = "RoleId")]
        public int RoleId { get; set; }
        public IFormFile UploadAvt { get; set; }
    }
}
