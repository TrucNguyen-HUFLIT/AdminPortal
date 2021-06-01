using Application.Models.Profile;
using Data.EF;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Application.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Profile
{
    public class ProfileService : IProfileService, IHashPassword
    {
        private readonly AdminContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProfileService(AdminContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<Models.Profile.AccountRequest> GetModelByClaimAsync(ClaimsPrincipal claimsPrincipal)
        {
            string email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

            if (email != null)
            {
                var account = await GetAccountByIdOrEmailAsync(0, email);
                var model = new Models.Profile.AccountRequest
                {
                    AccId = account.AccId,
                    Email = account.Email,
                    Password = account.Password,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Avatar = account.Avatar,
                    RoleId = account.RoleId
                };

                SessionAcc.Avatar = model.Avatar;
                SessionAcc.Name = model.FirstName + " " + model.LastName;
                SessionAcc.Role = await _context.Roles
                    .Where(x => x.RoleId == model.RoleId)
                    .Select(x => x.Name)
                    .FirstOrDefaultAsync();

                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> IndexAsync(Models.Profile.AccountRequest request)
        {
            var model = await _context.Accounts
                .Where(x => x.AccId == request.AccId)
                .FirstOrDefaultAsync();

            if (model.Password == HashPassword(request.Password))
            {
                //Change Tracking
                model.FirstName = request.FirstName;
                model.LastName = request.LastName;
                _context.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> ChangeImageAsync(ProfileChangeImage profileChangeImage)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(profileChangeImage.UploadAvt.FileName);
            string extension = Path.GetExtension(profileChangeImage.UploadAvt.FileName);
            fileName += extension;
            string path = Path.Combine(wwwRootPath + "/img/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await profileChangeImage.UploadAvt.CopyToAsync(fileStream);
            }
            profileChangeImage.Avatar = "/img/" + fileName;

            var model = await GetAccountByIdOrEmailAsync(profileChangeImage.AccId, "");
            model.Avatar = profileChangeImage.Avatar;

            _context.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> ChangePasswordAsync(ProfileChangePassword profileChangePassword)
        {
            var model = await GetAccountByIdOrEmailAsync(profileChangePassword.AccId, "");

            if (model.Password == HashPassword(profileChangePassword.OldPassword))
            {
                model.Password = HashPassword(profileChangePassword.Password);
                _context.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<Models.Profile.AccountRequest> GetModelAccountRequestByIdAsync(int id)
        {
            var model = await _context.Accounts
                .Where(x => x.AccId == id)
                .FirstOrDefaultAsync();

            if (model != null)
            {
                var accountRequest = new Models.Profile.AccountRequest
                {
                    AccId = model.AccId,
                    Email = model.Email,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Avatar = model.Avatar,
                    RoleId = model.RoleId
                };
                return accountRequest;
            }
            return null;
        }
        public async Task<AccountEdit> GetModelAccountEditByIdAsync(int id)
        {
            var model = await _context.Accounts
                .Where(x => x.AccId == id)
                .Select(x => new { x.AccId, x.Email, x.FirstName, x.LastName, x.Avatar, x.RoleId })
                .FirstOrDefaultAsync();

            if (model != null)
            {
                var accountRequest = new AccountEdit
                {
                    AccId = model.AccId,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Avatar = model.Avatar,
                    RoleId = model.RoleId
                };
                return accountRequest;
            }
            return null;
        }

        public async Task<ProfileChangePassword> GetModelProfileChangePasswordByIdAsync(int id)
        {
            var model = await _context.Accounts
                .Where(x => x.AccId == id)
                .Select(x => new { x.AccId, x.Password })
                .FirstOrDefaultAsync();

            if (model != null)
            {
                var profileChangePassword = new ProfileChangePassword
                {
                    AccId = model.AccId,
                    Password = model.Password
                };
                return profileChangePassword;
            }
            return null;
        }
        private async Task<Data.Entities.Account> GetAccountByIdOrEmailAsync(int id, string email)
        {
            var account = await _context.Accounts.Where(x => x.AccId == id || x.Email == email).FirstOrDefaultAsync();
            return account;
        }

        public string HashPassword(string password)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            //nếu bạn muốn các chữ cái in thường thay vì in hoa thì bạn thay chữ "X" in hoa trong "X2" thành "x"
            return sb.ToString();
        }

    }
}
