using AutoMapper;
using HookahCulture.Data.Models;
using HookahCulture.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HookahCulture.Web.ViewModels.Gallery
{
    public class GalleryImageInputViewModel : IMapFrom<Image>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public bool IsApproved { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public string UserWhoUploaded { get; set; }

        public string UserTimeLineId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Image, GalleryImageInputViewModel>()
                .ForMember(x => x.UpVotes, options =>
                {
                    options.MapFrom(p => p.GalleryVotes.Where(v => v.IsUpVote == true).Count());
                })
                .ForMember(x => x.DownVotes, options =>
                {
                    options.MapFrom(p => p.GalleryVotes.Where(v => v.IsUpVote == false).Count());
                });
        }
    }
}
