using Application.Models.Profile;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Models.Account;

namespace Application.Services.Profile
{
    public interface IProfileService
    {
        Task<Models.Profile.AccountRequest> GetModelByClaimAsync(ClaimsPrincipal claimsPrincipal);
        Task<bool> IndexAsync(Models.Profile.AccountRequest request);

        Task<bool> ChangeImageAsync(ProfileChangeImage profileChangeImage);

        Task<bool> ChangePasswordAsync(ProfileChangePassword profileChangePassword);
        Task<Models.Profile.AccountRequest> GetModelAccountRequestByIdAsync(int id);
        Task<AccountEdit> GetModelAccountEditByIdAsync(int id);

        Task<ProfileChangePassword> GetModelProfileChangePasswordByIdAsync(int id);


    }
}
