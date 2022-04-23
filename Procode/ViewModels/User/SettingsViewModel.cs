using Procode.Data.DTO.Requests;
using Procode.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.User
{
    public class SettingsViewModel : ChangePasswordRequest
    {
        [Required]
        [Display(Name = "Foydalanuvchi nomi")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Elektron pochta manzil")]
        public string Email { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Display(Name = "URL")]
        public string WebsiteUri { get; set; }

        [Display(Name = "Ish yoki o'qish manzilingiz")]
        public string Company { get; set; }

        [Display(Name = "Email profilda ko'rsatilsin")]
        public bool DisplayEmail { get; set; }

        public string Status { get; set; }

        public string IdentityName { get; set; }

    }
}
