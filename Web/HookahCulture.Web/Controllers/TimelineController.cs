using HookahCulture.Data.Models;
using HookahCulture.Services.Data;
using HookahCulture.Web.ViewModels.Home;
using HookahCulture.Web.ViewModels.PersonalTimeline;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahCulture.Web.Controllers
{
    public class TimelineController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;

        public TimelineController(UserManager<ApplicationUser> userManager, IPostsService postsService)
        {
            this.userManager = userManager;
            this.postsService = postsService;
        }

        public IActionResult PersonalTimeLine()
        {
            var userId = this.userManager.GetUserId(this.User);

            var posts = this.postsService.GetAllPostsForSpecificUserTimeLine<IndexPostViewModel>(userId);

            var viewModel = new PersonalTimelineInputViewModel()
            {
                Posts = posts,
            };

            return this.View(viewModel);
        }
    }
}
