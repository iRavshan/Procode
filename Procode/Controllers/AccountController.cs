using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Procode.Data.DTO;
using Procode.Data.DTO.Requests;
using Procode.Data.DTO.Responses;
using Procode.Data.Interfaces;
using Procode.Domain.Models;
using Procode.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Procode.Controllers
{

    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel
            {
                PageTitle = "Hisobga kirish"
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private readonly IUserRepository userRepos;

        public AccountController(IUserRepository userRepos)
        {
            this.userRepos = userRepos;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
                UserLoginRequest request = new UserLoginRequest
                {
                    Email = model.Email,
                    Password = model.Password
                };

                AuthResponse res = await userRepos.Login(request);

                if (res.Succes)
                {
                    return View();
                }
                
                return View();  
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
