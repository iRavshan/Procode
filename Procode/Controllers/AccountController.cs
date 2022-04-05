using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Procode.Data.DTO;
using Procode.Data.Interfaces;
using Procode.Domain.Models;
using Procode.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserRepository userRepos;

        public AccountController(IUserRepository userRepos)
        {
            this.userRepos = userRepos;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel
            {
                PageTitle = "Hisobga kirish"
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            UserLoginRequest request = new UserLoginRequest
            {
                Email = model.Email,
                Password = model.Password
            };

            userRepos.Login(request);

            if (User.Identity.IsAuthenticated)
            {
                return View("~/Home/Index");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
