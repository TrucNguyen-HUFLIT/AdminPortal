using X.PagedList;

namespace Application.Models.Account
{
    public class AccountViewModel
    {
        public AccountLogin AccountLogin { get; set; }
        public AccountRegister AccountRegister { get; set; }
        public AccountRequest AccountRequest { get; set; }
        public IPagedList<AccountRequest> ListAccountRequest { get; set; }
    }
}
