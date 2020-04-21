using HookahCulture.Data.Models;
using HookahCulture.Services.Data;
using HookahCulture.Web.ViewModels.Gallery;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HookahCulture.Web.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IUploadsService uploadsService;
        private readonly IImagesService imagesService;
        private readonly UserManager<ApplicationUser> userManager;

        public GalleryController(IWebHostEnvironment hostingEnvironment, IUploadsService uploadsService, IImagesService imagesService, UserManager<ApplicationUser> userManager)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.uploadsService = uploadsService;
            this.imagesService = imagesService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new GalleryViewModel();
            var images = this.imagesService.GetAllImages<GalleryImageInputViewModel>().ToList();

            viewModel.Images = images;

            return this.View(viewModel);
        }

        public async Task<IActionResult> UploadImage(GalleryViewModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            string uniqueFileName = null;

            if (model.ImageUpload != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/Gallery");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageUpload.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.ImageUpload.CopyTo(new FileStream(filePath, FileMode.Create));

                this.uploadsService.UploadImageInGallery(user, uniqueFileName);
            }

            return this.Redirect("/Gallery/Index");
        }
    }
}
