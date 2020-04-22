using HookahCulture.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HookahCulture.Web.ViewModels.Gallery
{
    public class GalleryViewModel
    {
        public ICollection<GalleryImageInputViewModel> Images { get; set; }

        public IFormFile ImageUpload { get; set; }

        public IEnumerable<ApplicationUser> RecentlyRegisteredUsers { get; set; }

    }
}
