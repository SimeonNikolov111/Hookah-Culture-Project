using HookahCulture.Web.ViewModels.Home;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HookahCulture.Web.ViewModels.PersonalTimeline
{
    public class PersonalTimelineInputViewModel
    {
        public IEnumerable<IndexPostViewModel> Posts { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public IFormFile PostCreationPictureUpload { get; set; }

        public IFormFile ProfilePicture { get; set; }

        public IFormFile CoverPhoto { get; set; }
    }
}
