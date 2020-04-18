using HookahCulture.Data;
using HookahCulture.Data.Common.Repositories;
using HookahCulture.Data.Models;
using HookahCulture.Services.Mapping;
using HookahCulture.Web.ViewModels.Home;
using HookahCulture.Web.ViewModels.PersonalTimeline;
using HookahCulture.Web.ViewModels.Posts;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public IEnumerable<T> GetAllPosts<T>(int? take = 5, int skip = 0)
        {
            var posts = this.dbContext.Posts.OrderByDescending(p => p.CreatedOn).Skip(skip);

            if (take.HasValue)
            {
                posts = posts.Take(take.Value);
            }

            return posts.To<T>().ToList();
        }

        public IEnumerable<T> GetAllPostsForSpecificUserTimeLine<T>(string userId, int? take = 5, int skip = 0)
        {
            var posts = this.dbContext.Posts.Where(p => p.UserId == userId).OrderByDescending(p => p.CreatedOn).Skip(skip);

            if (take.HasValue)
            {
                posts = posts.Take(take.Value);
            }

            return posts.To<T>().ToList();
        }


        public void Create(string text, string imagePath, string userId)
        {
            var user = this.dbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
            var post = new Post()
            {
                Text = text,
                ImagePath = imagePath,
                UserId = userId,
                User = user,
            };

            this.dbContext.Posts.Add(post);
            this.dbContext.SaveChanges();
        }

        public int GetCountOfPosts()
        {
            return this.dbContext.Posts.Count();
        }

        public int GetCountOfPostsForSpecificUser(string userId)
        {
            return this.dbContext.Posts.Where(p => p.UserId == userId).Count();
        }
    }
}
