using HookahCulture.Data.Common.Repositories;
using HookahCulture.Data.Models;
using HookahCulture.Services.Mapping;
using HookahCulture.Web.ViewModels.Home;
using HookahCulture.Web.ViewModels.Posts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostsService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public IEnumerable<T> GetAllPosts<T>()
        {
            var posts = this.postRepository.All().To<T>();

            return posts;
        }

        public async Task CreateAsync(string text, string imageUrl, string userId)
        {
            var post = new Post()
            {
                Text = text,
                ImageUrl = imageUrl,
                UserId = userId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
        }
    }
}
