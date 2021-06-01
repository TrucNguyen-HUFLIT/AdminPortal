using Application.Models.Account;
using Data.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Profile;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography;
using X.PagedList;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;

namespace Application.Services.Account
{
    public class AccountService : IAccountService, IHashPassword
    {
        private readonly AdminContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AccountService(AdminContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<ClaimsPrincipal> LoginAsync(AccountLogin request)
        {
            var model = await _context.Accounts
                .Where(x => x.Email == request.Email && x.Password == HashPassword(request.Password))
                .Select(x => new { x.Email, x.Password, x.RoleId })
                .FirstOrDefaultAsync();

            //var model =  await (from account in _context.Accounts
            //             where account.Email == request.Email || account.Password == HashPassword(request.Password)
            //             select new { account.Email, account.Password, account.RoleId }).FirstOrDefaultAsync();

            if (model != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, request.Email),

                    //ClaimTypes.Role dùng để check [Authorize(Roles)]
                    new Claim(ClaimTypes.Role, await _context.Roles.Where(x=>x.RoleId == model.RoleId)
                                                                    .Select(x=>x.Name)
                                                                    .FirstOrDefaultAsync()),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                return claimsPrincipal;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> RegisterAsync(AccountRegister request)
        {
            var email = await _context.Accounts
                .Where(x => x.Email == request.Email)
                .Select(x=>x.Email)
                .FirstOrDefaultAsync();

            if (email == null)
            {
                var model = new Data.Entities.Account
                {
                    Email = request.Email,
                    Password = HashPassword(request.Password),
                    Avatar = "/img/avatar-default-icon.png",
                    RoleId = 2
                };
                _context.Accounts.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(AccountEdit request)
        {
            //Change Tracking
            var model = await _context.Accounts
                .Where(x => x.AccId == request.AccId)
                .FirstOrDefaultAsync();

            model.FirstName = request.FirstName;
            model.LastName = request.LastName;

            _context.Update(model);
            await _context.SaveChangesAsync();
            return true;
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

            //Change Tracking
            var model = await _context.Accounts
                .Where(x => x.AccId == profileChangeImage.AccId)
                .FirstOrDefaultAsync();

            model.Avatar = profileChangeImage.Avatar;

            _context.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(AccountEdit request)
        {
            var model =  await _context.Accounts
                .Where(x => x.AccId == request.AccId)
                .FirstOrDefaultAsync();

            if (model != null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }

            else return false;
        }

        public async Task CreateAsync(AccountCreate request)
        {
            var email = await _context.Accounts
                .Where(x => x.Email == request.Email)
                .Select(x=>x.Email)
                .FirstOrDefaultAsync();

            if (email != null)
            {
                throw new EmailExistedException(email);
            }

            var model = new Data.Entities.Account
            {
                Email = request.Email,
                Password = HashPassword(request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName,
                RoleId = request.RoleId
            };

            #region Save Image from wwwroot/img
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName;
            string extension;
            if (request.UploadAvt != null)
            {
                fileName = Path.GetFileNameWithoutExtension(request.UploadAvt.FileName);
                extension = Path.GetExtension(request.UploadAvt.FileName);
                model.Avatar = "/img/" + fileName + extension;
                string path1 = Path.Combine(wwwRootPath + "/img/", fileName);
                using var fileStream = new FileStream(path1, FileMode.Create);
                await request.UploadAvt.CopyToAsync(fileStream);
            }
            else
            {
                model.Avatar = "/img/avatar-default-icon.png";
            }
            #endregion

            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IPagedList<Models.Account.AccountRequest>> GetListAccountRequestAsync(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var model = new List<Models.Account.AccountRequest>();
            var listAccount = await _context.Accounts.ToListAsync();

            if (listAccount != null)
            {

                foreach (var account in listAccount)
                {
                    var accountRequest = new Models.Account.AccountRequest
                    {
                        AccId = account.AccId,
                        Email = account.Email,
                        Password = account.Password,
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        Avatar = account.Avatar,
                        RoleId = account.RoleId
                    };
                    model.Add(accountRequest);
                }
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = model.Where(s => s.FirstName.Contains(searchString)
                                            || s.LastName.Contains(searchString)
                                            || s.Email.Contains(searchString)).ToList();
                }
                model = sortOrder switch
                {
                    "lastname_desc" => model.OrderByDescending(x => x.LastName).ToList(),
                    "lastname" => model.OrderBy(x => x.LastName).ToList(),
                    "firstname_desc" => model.OrderByDescending(x => x.FirstName).ToList(),
                    "firstname" => model.OrderBy(x => x.FirstName).ToList(),
                    "id_desc" => model.OrderByDescending(x => x.AccId).ToList(),
                    _ => model.OrderBy(x => x.AccId).ToList(),
                };
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return model.ToPagedList(pageNumber, pageSize);
            }
            return null;
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
