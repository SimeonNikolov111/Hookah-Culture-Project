using HookahCulture.Services.Mapping;
using HookahCulture.Data.Models;

namespace HookahCulture.Web.ViewModels.Posts
{
    public class CreatePostInputViewModel : IMapFrom<Post>
    {
        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }
    }
}
