namespace HookahCulture.Data.Models
{
    using System.Collections.Generic;

    using HookahCulture.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public int Likes { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
