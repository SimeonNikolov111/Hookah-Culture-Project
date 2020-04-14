using HookahCulture.Services.Mapping;
using HookahCulture.Data.Models;
using Microsoft.AspNetCore.Http;

namespace HookahCulture.Web.ViewModels.Posts
{
    public class CreatePostInputViewModel : IMapFrom<Post>
    {
        public string Text { get; set; }

        public IFormFile PostCreationPictureUpload { get; set; }

        public string UserId { get; set; }
    }
}
