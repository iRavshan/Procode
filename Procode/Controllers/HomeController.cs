using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Procode.Data.Interfaces;
using Procode.Domain.Models;
using Procode.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISpeakerRepository speakerRepo;
        private readonly IContentRepository contentRepo;
        private readonly IFeedbackRepository feedbackRepo;

        public HomeController(ILogger<HomeController> logger,
                              ISpeakerRepository speakerRepo,
                              IContentRepository contentRepo,
                              IFeedbackRepository feedbackRepo)
        {
            _logger = logger;
            this.speakerRepo = speakerRepo;
            this.contentRepo = contentRepo;
            this.feedbackRepo = feedbackRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                PageTitle = "Bosh sahifa",
                LastContents = await contentRepo.LastContents(3)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Blog()
        {
            BlogViewModel model = new BlogViewModel
            {
                PageTitle = "Blog",
                BannerTitle = "Procode hamjamiyati",
                Contents = Enumerable.Reverse(await contentRepo.GetAll()),
                LastContents = await contentRepo.LastContents(3)
            };

            return View(model);
        }

        public async Task<IActionResult> Content([FromRoute] Guid Id)
        {
            ContentViewModel model = new ContentViewModel
            {
                PageTitle = (await contentRepo.GetById(Id)).Name,
                BannerTitle = (await contentRepo.GetById(Id)).Name,
                Content = await contentRepo.GetById(Id),
                LastContents = await contentRepo.LastContents(3)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Blog(BlogViewModel model)
        {
            if (model.Search != null)
            {
                BlogViewModel newModel = new BlogViewModel
                {
                    PageTitle = "Blog",
                    BannerTitle = "Foydali blog",
                    Contents = await contentRepo.SearchContent(model.Search),
                    LastContents = await contentRepo.LastContents(3),
                    Search = model.Search
                };

                return View(newModel);
            }

            else
            {
                BlogViewModel exModel = new BlogViewModel

                {
                    PageTitle = "Blog",
                    BannerTitle = "Foydali blog",
                    Contents = Enumerable.Reverse(await contentRepo.GetAll()),
                    LastContents = await contentRepo.LastContents(3),
                    Search = model.Search
                };

                return View(exModel);
            }



        }

        public IActionResult Contact()
        {
            ContactViewModel model = new ContactViewModel
            {
                PageTitle = "Aloqa",
                BannerTitle = "Aloqa",
                BannerSubtitle = "Fikr va takliflaringizni biz bilan baham ko'ring"
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                Feedback feedback = new Feedback
                {
                    Id = Guid.NewGuid(),
                    Subject = model.Subject,
                    Text = model.Text
                };

                await feedbackRepo.Create(feedback);
            }
            



            return View();
        }

        public IActionResult Books()
        {
            return View();
        }

    }
}
