using HookahCulture.Data;
using HookahCulture.Data.Models;
using HookahCulture.Services.Data;
using HookahCulture.Web.ViewModels.Home;
using HookahCulture.Web.ViewModels.PersonalTimeline;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HookahCulture.Web.Controllers
{
    public class TimelineController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IUploadsService uploadsService;

        public TimelineController(UserManager<ApplicationUser> userManager, IPostsService postsService, IWebHostEnvironment hostingEnvironment, IUploadsService uploadsService)
        {
            this.userManager = userManager;
            this.postsService = postsService;
            this.hostingEnvironment = hostingEnvironment;
            this.uploadsService = uploadsService;
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

        public async Task<IActionResult> UploadProfilePicture(PersonalTimelineInputViewModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            string uniqueFileName = null;
            if (model.ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/ProfilePictures");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.ProfilePicture.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            await this.uploadsService.UploadProfilePicture(user, uniqueFileName);

            return this.Redirect("/Timeline/PersonalTimeLine");
        }

        public async Task<IActionResult> UploadCoverPhoto(PersonalTimelineInputViewModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            string uniqueFileName = null;
            if (model.CoverPhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/CoverPhotos");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CoverPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.CoverPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            await this.uploadsService.UploadCoverPhoto(user, uniqueFileName);

            return this.Redirect("/Timeline/PersonalTimeLine");
        }
    }
}
