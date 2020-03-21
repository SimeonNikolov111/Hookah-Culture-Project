using HookahCulture.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace HookahCulture.Services.Data
{
    public interface IPostsService
    {
        IEnumerable<IndexPostViewModel> GetAllPosts();
    }
}
