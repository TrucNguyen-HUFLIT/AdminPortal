using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Application.Models.Profile;
using Application.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Application.Services.Profile;
using AdminPortal.Filters;

namespace AdminPortal.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IProfileService _profileService;

        public AccountController(IProfileService profileService, IAccountService accountService)
        {
            _profileService = profileService;
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("firstname") ? "firstname_desc" : "firstname";
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("lastname") ? "lastname_desc" : "lastname";
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var model = new AccountViewModel
            {
                ListAccountRequest = await _accountService.GetListAccountRequestAsync(sortOrder, currentFilter, searchString, page)
            };
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Login");
        }

        [ServiceFilter(typeof(ModelStateAjaxFilter))]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountLogin accountLogin)
        {
            #region code cũ
            //var isValid = _database.Accounts.Any(x => x.Email == accountLogin.Email && x.Password == accountLogin.Password);
            //if (isValid)
            //{
            //    var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            //    claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, accountLogin.Email));
            //    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            //    await HttpContext.SignInAsync(claimsPrincipal);

            //    HttpContext.Session.SetString("email", accountLogin.Email);
            //    return Ok();
            //}
            //else
            //{
            //    return Unauthorized();
            //}
            #endregion
            var claimsPrincipal = await _accountService.LoginAsync(accountLogin);
            if (claimsPrincipal != null)
            {
                await HttpContext.SignInAsync(claimsPrincipal);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View("Login");
        }

        [ServiceFilter(typeof(ModelStateAjaxFilter))]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(AccountRegister accountRegister)
        {
            #region code cũ
            //var model = new AccountViewModel();
            //model.ListAccountRequest = _database.Accounts.ToArray();
            //bool isExist = false, isEmailFormat = false;
            //foreach (var item in model.ListAccountRequest)
            //{
            //    if (item.Email == accountRegister.Email)
            //    {
            //        isExist = true;
            //        break;
            //    }
            //    //if (item.Email.Where(").Count() >= 1)
            //    //{


            //    //    isExist = true;
            //    //    break;
            //    //}
            //}
            //if (ModelState.IsValid && accountRegister.Password == accountRegister.ConfirmPassword && !isExist)
            //{
            //    if (!IsCheckPassword(accountRegister.Password))
            //    {
            //        ViewBag.ErrorPassword = "Password contains at least 1 uppercase letters and at least 1 numbers, and the entire string is longer than 6";
            //        return View(model);
            //    }
            //    model.AccountRequest = new AccountRequest();
            //    model.AccountRequest.Email = accountRegister.Email;
            //    model.AccountRequest.Password = accountRegister.Password;
            //    model.AccountRequest.Avatar = "/img/avatar-default-icon.png";
            //    _database.Add(model.AccountRequest);
            //    _database.SaveChanges();
            //    return Ok();
            //}
            //else
            //{
            //    return BadRequest();
            //}
            #endregion

            if (await _accountService.RegisterAsync(accountRegister))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Active = "active";
            #region code cũ
            //string email = HttpContext.Session.get....
            //if (email != null)
            //{
            //    var modelcheck = new ProfileViewModel();
            //    modelcheck.AccountRequest = _database.Accounts.Where(x => x.Email == email).FirstOrDefault();
            //    if (!modelcheck.AccountRequest.Role)
            //    {
            //        return Forbid();
            //    }

            //    var model = new ProfileViewModel();
            //    model.AccountRequest = _database.Accounts.Where(x => x.AccId == id).FirstOrDefault();
            //    return View(model);
            //}
            //else
            //{
            //    return NotFound();
            //}

            //var model = new AccountViewModel();
            //model.AccountRequest = _profileService.GetModelByClaim(User);
            //if (model != null)
            //{
            //    var model = new ProfileViewModel();
            //    model.AccountRequest = _database.Accounts.Where(x => x.AccId == id).FirstOrDefault();
            //    return View(model);
            //}
            //else
            //{
            //    return NotFound();
            //}
            #endregion
            var model = new ProfileViewModel
            {
                AccountEdit = await _profileService.GetModelAccountEditByIdAsync(id)
            };
            return View(model);
        }

        [ServiceFilter(typeof(ModelStateAjaxFilter))]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(AccountEdit accountEdit)
        {
            #region code cũ
            //var model = new ProfileViewModel();

            //model.AccountRequest = _database.Accounts.Where(x => x.AccId == accountRequest.AccId).FirstOrDefault();

            //if (accountRequest.Email != null && accountRequest.Password != null && accountRequest.FirstName != null && accountRequest.LastName != null)
            //{
            //    if (!IsCheckPassword(accountRequest.Password))
            //    {
            //        ViewBag.ErrorPassword = "Password contains at least 1 uppercase letters and at least 1 numbers, and the entire string is longer than 6";
            //        return View(model);
            //    }
            //    model.AccountRequest.Email = accountRequest.Email;
            //    model.AccountRequest.Password = accountRequest.Password;
            //    model.AccountRequest.FirstName = accountRequest.FirstName;
            //    model.AccountRequest.LastName = accountRequest.LastName;
            //    _database.Update(model.AccountRequest);
            //    _database.SaveChanges();
            //    return RedirectToAction("Edit");
            //}
            //return RedirectToAction("Edit", "Account", new { id = model.AccountRequest.AccId });

            //version 2
            //    if (ModelState.IsValid)
            //    {
            //        if (await _accountService.EditAsync(accountEdit))
            //            return RedirectToAction("Edit", new { id = accountEdit.AccId });
            //    }
            //var model = new ProfileViewModel();
            //    var accEdit = await _profileService.GetModelAccountEditByIdAsync(accountEdit.AccId);
            //    model.AccountEdit = accountEdit;
            //    model.AccountEdit.Avatar = accEdit.Avatar;
            //    return View(model);
            #endregion

            await _accountService.EditAsync(accountEdit);
            return Ok(accountEdit.AccId);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeImageEdit(ProfileChangeImage profileChangeImage)
        {
            #region code cũ
            //var model = new ProfileViewModel();
            //model.AccountRequest = _database.Accounts.Where(x => x.AccId == profileChangeImage.AccId).FirstOrDefault();

            //#region Save Image from wwwroot/img
            //string wwwRootPath = hostEnvironment.WebRootPath;
            //string fileName = Path.GetFileNameWithoutExtension(profileChangeImage.UploadAvt.FileName);
            //string extension = Path.GetExtension(profileChangeImage.UploadAvt.FileName);
            //fileName += extension;
            //string path = Path.Combine(wwwRootPath + "/img/", fileName);

            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
            //    await profileChangeImage.UploadAvt.CopyToAsync(fileStream);
            //}
            //model.AccountRequest.Avatar = "/img/" + fileName;
            //#endregion

            //_database.Update(model.AccountRequest);
            //_database.SaveChanges();
            ////Post-Redirect-Get Pattern
            //return RedirectToAction("Edit", "Account", new { id = model.AccountRequest.AccId });
            #endregion

            await _accountService.ChangeImageAsync(profileChangeImage);
            return RedirectToAction("Edit", new { id = profileChangeImage.AccId });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Active = "active";
            return View(new ProfileViewModel());
        }

        [ServiceFilter(typeof(ModelStateAjaxFilter))]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(AccountCreate accountCreate)
        {
            #region code cũ
            //var model = new AccountRequest();
            //var modelList = _database.Accounts.ToArray();
            //bool isExist = false;
            //foreach (var item in modelList)
            //{
            //    if (item.Email == accountCreate.Email)
            //    {
            //        isExist = true;
            //        break;
            //    }
            //}
            //if (ModelState.IsValid)
            //{
            //    if (isExist)
            //    {
            //        ViewBag.EmailExisted = "Email already exists!";
            //        return View(accountCreate);
            //    }
            //    if (!IsCheckPassword(accountCreate.Password))
            //    {
            //        ViewBag.ErrorPassword = "Password contains at least 1 uppercase letters and at least 1 numbers, and the entire string is longer than 6";
            //        return View(accountCreate);
            //    }
            //    model.Email = accountCreate.Email;
            //    model.Password = accountCreate.Password;
            //    model.FirstName = accountCreate.FirstName;
            //    model.LastName = accountCreate.LastName;
            //    model.Role = accountCreate.Role;

            //    #region Save Image from wwwroot/img
            //    string wwwRootPath = hostEnvironment.WebRootPath;
            //    string fileName;
            //    string extension;
            //    if (accountCreate.UploadAvt != null)
            //    {
            //        fileName = Path.GetFileNameWithoutExtension(accountCreate.UploadAvt.FileName);
            //        extension = Path.GetExtension(accountCreate.UploadAvt.FileName);
            //        model.Avatar = fileName += extension;
            //        string path1 = Path.Combine(wwwRootPath + "/img/", fileName);
            //        using (var fileStream = new FileStream(path1, FileMode.Create))
            //        {
            //            await accountCreate.UploadAvt.CopyToAsync(fileStream);
            //        }
            //    }
            //    else
            //    {
            //        model.Avatar = "/img/avatar-default-icon.png";
            //    }
            //    #endregion

            //    _database.Add(model);
            //    await _database.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(accountCreate);


            //version 2
            //if (await _accountService.CreateAsync(accountCreate))
            //{
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    ViewBag.EmailExisted = "Email already exists";
            //    return View(accountCreate);
            //}
            #endregion

            await _accountService.CreateAsync(accountCreate);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(AccountEdit accountEdit)
        {
            await _accountService.DeleteAsync(accountEdit);
            return Ok();
        }
    }
}
