using HookahCulture.Data.Models;
using HookahCulture.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public interface IPostsService
    {
        IEnumerable<T> GetAllPosts<T>(int? take = 5, int skip = 0);

        IEnumerable<T> GetAllPostsForSpecificUserTimeLine<T>(string userId, int? take = 5, int skip = 0);

        void Create(string text, string imageUrl, string userId);

        void Delete(int postId);

        int GetCountOfPosts();

        int GetCountOfPostsForSpecificUser(string userId);

        ICollection<ApplicationUser> GetRecentlyRegisteredUsers();
    }
}
