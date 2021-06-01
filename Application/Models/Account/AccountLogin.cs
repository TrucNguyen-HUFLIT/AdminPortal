using System.ComponentModel.DataAnnotations;

namespace Application.Models.Account
{
    public class AccountLogin
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
