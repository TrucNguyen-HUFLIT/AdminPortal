using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Application.Models.Profile;
using Application.Services.Profile;
using AdminPortal.Filters;

namespace AdminPortal.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IWebHostEnvironment hostEnvironment;

        public ProfileController(IProfileService profileService, IWebHostEnvironment hostEnvironment)
        {
            _profileService = profileService;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.ActiveProfile = "active";

            var model = new ProfileViewModel
            {
                AccountRequest = await _profileService.GetModelByClaimAsync(User)
            };

            if (model != null)
            {
                ViewBag.Done = TempData["done"];
                ViewBag.OldPassword = TempData["PW"];
                return View(model);
            }
            else
            {

                return NotFound();
            }
        }

        [ServiceFilter(typeof(ModelStateFilter))]
        [HttpPost]
        public async Task<IActionResult> Index(AccountRequest accountRequest)
        {
            var model = new ProfileViewModel
            {
                AccountRequest = await _profileService.GetModelAccountRequestByIdAsync(accountRequest.AccId)
            };

            if (await _profileService.IndexAsync(accountRequest))
                return RedirectToAction("Index");
            else
                return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeImage(ProfileChangeImage profileChangeImage)
        {
            await _profileService.ChangeImageAsync(profileChangeImage);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ProfileChangePassword profileChangePassword)
        {
            var model = new ProfileViewModel
            {
                AccountRequest = await _profileService.GetModelByClaimAsync(User),
                ProfileChangePassword = await _profileService.GetModelProfileChangePasswordByIdAsync(profileChangePassword.AccId)
            };

            if (ModelState.IsValid)
            {
                #region code cũ
                //if (model.AccountRequest.Password != profileChangePassword.OldPassword)
                //{
                //    TempData["PW"] = "Old Password is wrong!";
                //    return RedirectToAction("Index");
                //}
                //if (!IsCheckPassword(profileChangePassword.Password))
                //{

                //    TempData["errorPW"] = "Password contains at least 1 uppercase letters and at least 1 numbers, and the entire string is longer than 6";
                //    return RedirectToAction("Index");
                //}
                //if (profileChangePassword.Password != profileChangePassword.ConfirmPassword)
                //{
                //    TempData["confirmPW"] = "Password and Confirm Password must match!";
                //    return RedirectToAction("Index");
                //}
                //TempData["done"] = "Password changed successfully";
                //model.AccountRequest.Password = profileChangePassword.Password;
                //_database.Update(model.AccountRequest);
                //_database.SaveChanges();
                //return RedirectToAction("Index");
                #endregion

                if (await _profileService.ChangePasswordAsync(profileChangePassword))
                    TempData["done"] = "Password changed successfully";
                else
                    TempData["PW"] = "Invalid Password";

                return RedirectToAction("Index");
            }
            return View("Index", model);
        }

    }

}
