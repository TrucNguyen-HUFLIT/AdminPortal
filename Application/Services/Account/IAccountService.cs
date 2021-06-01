using Application.Models.Account;
using Application.Models.Profile;
using X.PagedList;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Services.Account
{
    public interface IAccountService
    {
        Task<ClaimsPrincipal> LoginAsync(AccountLogin request);
        Task<bool> RegisterAsync(AccountRegister request);
        Task<bool> EditAsync(AccountEdit request);
        Task<bool> ChangeImageAsync(ProfileChangeImage profileChangeImage);
        Task<bool> DeleteAsync(AccountEdit request);
        Task CreateAsync(AccountCreate request);
        Task<IPagedList<Models.Account.AccountRequest>> GetListAccountRequestAsync(string sortOrder, string currentFilter, string searchString, int? page);
    }
}
