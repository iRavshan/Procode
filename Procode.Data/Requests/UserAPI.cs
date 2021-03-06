using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Requests
{
    public class UserAPI
    {
        public static readonly string GetById = "user/getbyid?Id=";
        public static readonly string Delete = "user/delete?Email=";
        public static readonly string Update = "user/update";
        public static readonly string Login = "account/login";
        public static readonly string Register = "account/register";
        public static readonly string ChangePassword = "account/changepassword";
    }
}
