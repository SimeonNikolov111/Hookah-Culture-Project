using HookahCulture.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HookahCulture.Data.Models
{
    public class GalleryVote : BaseModel<int>
    {
        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public bool IsUpVote { get; set; }
    }
}
