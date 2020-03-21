using HookahCulture.Data.Models;
using HookahCulture.Services.Mapping;

namespace HookahCulture.Web.ViewModels.Home
{
    public class IndexPostViewModel : IMapFrom<Post>
    {
        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public int Likes { get; set; }
    }
}