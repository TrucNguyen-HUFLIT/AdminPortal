using Application.Models.Account;

namespace Application.Models.Profile
{
    public class ProfileViewModel
    {
        public ProfileChangePassword ProfileChangePassword { get; set; }
        public ProfileChangeImage ProfileChangeImage { get; set; }
        public AccountRequest AccountRequest { get; set; }
        public AccountEdit AccountEdit { get; set; }
        public AccountCreate AccountCreate { get; set; }
    }
}
