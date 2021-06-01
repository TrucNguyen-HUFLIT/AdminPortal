using System.ComponentModel.DataAnnotations;

namespace Application.Models.Account
{
    public class AccountRegister
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
