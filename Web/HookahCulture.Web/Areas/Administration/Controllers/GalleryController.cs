namespace HookahCulture.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HookahCulture.Data.Models;
    using HookahCulture.Services.Data;
    using HookahCulture.Web.ViewModels.Gallery;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class GalleryController : Controller
    {
        private readonly IImagesService imagesService;
        private readonly IPostsService postsService;

        public GalleryController(IImagesService imagesService, IPostsService postsService)
        {
            this.imagesService = imagesService;
            this.postsService = postsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new GalleryViewModel();
            var images = this.imagesService.GetAllImagesForAdminApproval<GalleryImageInputViewModel>().ToList();
            var recenytlyRegisteredUsers = this.postsService.GetRecentlyRegisteredUsers();

            viewModel.Images = images;
            viewModel.RecentlyRegisteredUsers = recenytlyRegisteredUsers;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int imageId)
        {
            this.imagesService.GetImageForApproval(imageId);

            return this.RedirectToAction("Index");
        }
    }
}
