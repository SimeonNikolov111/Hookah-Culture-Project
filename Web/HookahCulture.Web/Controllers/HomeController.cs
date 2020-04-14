namespace HookahCulture.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using HookahCulture.Data.Models;
    using HookahCulture.Services.Data;
    using HookahCulture.Web.ViewModels;
    using HookahCulture.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private const int ItemsPerPage = 5;

        private readonly IPostsService postsService;

        public HomeController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [Authorize]
        public IActionResult Index(int page = 1)
        {
            var viewModel = new IndexViewModel();
            var posts = this.postsService.GetAllPosts<IndexPostViewModel>(ItemsPerPage, (page - 1) * ItemsPerPage);

            viewModel.Posts = posts;

            int count = this.postsService.GetCountOfPosts();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
