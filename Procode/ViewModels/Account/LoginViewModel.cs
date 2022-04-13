using Procode.Data.DTO;
using Procode.Data.DTO.Requests;
using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Account
{
    public class LoginViewModel :  UserLoginRequest
    {
        public string PageTitle { get; set; }
        public string Error { get; set; }
    }
}
