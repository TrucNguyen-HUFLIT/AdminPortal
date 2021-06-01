using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Profile
{
    public class ProfileChangeImage
    {
        [Display(Name = "ID Account")]
        public int AccId { get; set; }
        [Display(Name = "Avatar")]
        public string Avatar { get; set; }
        public IFormFile UploadAvt { get; set; }
    }
}
