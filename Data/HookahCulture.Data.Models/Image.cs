namespace HookahCulture.Data.Models
{
    using HookahCulture.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Image : BaseModel<int>
    {
        public Image()
        {
            this.GalleryVotes = new HashSet<GalleryVote>();
        }

        public string ImagePath { get; set; }

        public bool IsApproved { get; set; }

        public string UserWhoUploaded { get; set; }

        public string UserTimeLineId { get; set; }

        public ICollection<GalleryVote> GalleryVotes { get; set; }
    }
}
