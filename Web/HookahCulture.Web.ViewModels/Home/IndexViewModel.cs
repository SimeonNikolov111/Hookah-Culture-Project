namespace HookahCulture.Web.ViewModels.Home
{
    using AutoMapper;
    using HookahCulture.Data.Models;
    using HookahCulture.Services.Mapping;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class IndexViewModel
    {
        public IEnumerable<IndexPostViewModel> Posts { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public IFormFile PostCreationPictureUpload { get; set; }

        public IEnumerable<ApplicationUser> RecentlyRegisteredUsers { get; set; }
    }
}
