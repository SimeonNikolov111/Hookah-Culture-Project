using AutoMapper;
using HookahCulture.Data.Models;
using HookahCulture.Services.Mapping;
using HookahCulture.Web.ViewModels.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HookahCulture.Web.ViewModels.PersonalTimeline
{
    public class PersonalTimelineInputViewModel
    {
        public ApplicationUser User { get; set; }

        public IEnumerable<IndexPostViewModel> Posts { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public IFormFile PostCreationPictureUpload { get; set; }

        public IFormFile ProfilePicture { get; set; }

        public IFormFile CoverPhoto { get; set; }
    }
}
