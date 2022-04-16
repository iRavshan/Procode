using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.DTO.Requests
{
    public class UserRegisterRequest
    {
        [EmailAddress(ErrorMessage = "Email manzil noto'g'ri kiritilgan")]
        [Required(ErrorMessage = "Email manzilni kiriting")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu maydonni to'ldiring")]
        [MinLength(6, ErrorMessage = "Kamida 6 ta belgidan iborat bo'lishi kerak")]
        [RegularExpression(@"^[a-zA-Z0-9\_]+$", ErrorMessage = "Bu ism yaroqli emas")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Parolni kiriting")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parolni tasdiqlang")]
        public string ConfirmedPassword { get; set; }
    }
}
