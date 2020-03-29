using HookahCulture.Data;
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
        private readonly ApplicationDbContext dbContext;

        public PostsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<T> GetAllPosts<T>()
        {
            var posts = this.dbContext.Posts.To<T>().ToList();

            return posts;
        }

        public void Create(string text, string imageUrl, string userId)
        {
            var post = new Post()
            {
                Text = text,
                ImageUrl = imageUrl,
                UserId = userId,
            };

            this.dbContext.Posts.Add(post);
            this.dbContext.SaveChanges();
        }
    }
}
