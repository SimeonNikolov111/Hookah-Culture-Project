using AutoMapper;
using HookahCulture.Data.Models;
using HookahCulture.Services.Mapping;
using HookahCulture.Web.ViewModels.Comment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HookahCulture.Web.ViewModels.Home
{
    public class IndexPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Text { get; set; }

        public IFormFile Image { get; set; }

        public string ImagePath { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<CreateCommentInputViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, IndexPostViewModel>()
                .ForMember(x => x.UpVotes, options =>
                {
                    options.MapFrom(p => p.Votes.Where(v => v.IsUpVote == true).Count());
                })
                .ForMember(x => x.DownVotes, options =>
                {
                    options.MapFrom(p => p.Votes.Where(v => v.IsUpVote == false).Count());
                });
        }
    }
}