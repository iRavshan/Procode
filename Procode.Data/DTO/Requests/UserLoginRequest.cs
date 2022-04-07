using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.DTO.Requests
{
    public class UserLoginRequest
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email manzilni kiriting")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parolni kiriting")]
        public string Password { get; set; }
    }
}
