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

        public PostsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<T> GetAllPosts<T>(int? take = 5, int skip = 0)
        {
            var posts = this.dbContext.Posts.Where(p => p.IsDeleted == false).OrderByDescending(p => p.CreatedOn).Skip(skip);

            if (take.HasValue)
            {
                posts = posts.Take(take.Value);
            }

            return posts.To<T>().ToList();
        }

        public IEnumerable<T> GetAllPostsForSpecificUserTimeLine<T>(string userId, int? take = 5, int skip = 0)
        {
            var posts = this.dbContext.Posts.Where(p => p.UserId == userId && p.IsDeleted == false).OrderByDescending(p => p.CreatedOn).Skip(skip);

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

        public void Delete(int postId)
        {
            var post = this.dbContext.Posts.Where(p => p.Id == postId).FirstOrDefault();

            post.IsDeleted = true;

            this.dbContext.SaveChanges();
        }

        public ICollection<ApplicationUser> GetRecentlyRegisteredUsers()
        {
            var users = this.dbContext.Users.OrderByDescending(u => u.CreatedOn).Take(9).ToList();

            return users;
        }


        public int GetCountOfPosts()
        {
            return this.dbContext.Posts.Count();
        }

        public int GetCountOfPostsForSpecificUser(string userId)
        {
            return this.dbContext.Posts.Where(p => p.UserId == userId && p.IsDeleted == false).Count();
        }
    }
}
