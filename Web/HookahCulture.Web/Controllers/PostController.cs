namespace HookahCulture.Web.Controllers
{
    using System;
    using System.IO;

    using HookahCulture.Data.Models;
    using HookahCulture.Services.Data;
    using HookahCulture.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostController : Controller
    {
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        public PostController(IPostsService postsService, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            this.postsService = postsService;
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreatePostInputViewModel model)
        {
            string userId = this.userManager.GetUserId(this.User);

            string uniqueFileName = null;
            if (model.PostCreationPictureUpload != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PostCreationPictureUpload.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.PostCreationPictureUpload.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            this.postsService.Create(model.Text, uniqueFileName, userId);
            return this.Redirect("/Home/Index");
        }
    }
}
