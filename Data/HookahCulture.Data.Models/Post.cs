namespace HookahCulture.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HookahCulture.Data.Common.Models;
    using HookahCulture.Services.Mapping;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        public string Text { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
