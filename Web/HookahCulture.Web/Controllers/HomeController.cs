namespace HookahCulture.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using HookahCulture.Data.Common.Repositories;
    using HookahCulture.Data.Models;
    using HookahCulture.Web.ViewModels;
    using HookahCulture.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public HomeController(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var posts = this.postRepository.All().Select(x => new IndexPostViewModel
            {
                ImageUrl = x.ImageUrl,
                Text = x.Text,
                Likes = x.Likes,
            }).ToList();

            viewModel.Posts = posts;
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
