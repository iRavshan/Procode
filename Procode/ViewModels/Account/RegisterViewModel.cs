using Procode.Data.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Account
{
    public class RegisterViewModel : UserRegisterRequest
    {
        public string PageTitle { get; set; }
        public string Error { get; set; }
    }
}
