using HookahCulture.Data.Models;
using HookahCulture.Services.Mapping;
using System;

namespace HookahCulture.Web.ViewModels.Home
{
    public class IndexPostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}