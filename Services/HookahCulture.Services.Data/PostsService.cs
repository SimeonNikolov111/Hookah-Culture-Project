using HookahCulture.Data.Common.Repositories;
using HookahCulture.Data.Models;
using HookahCulture.Web.ViewModels.Home;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HookahCulture.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostsService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public IEnumerable<IndexPostViewModel> GetAllPosts()
        {
            var posts = this.postRepository.All().Select(x => new IndexPostViewModel
            {
                ImageUrl = x.ImageUrl,
                Text = x.Text,
                Likes = x.Likes,
            }).ToList();

            return posts;
        }
    }
}
