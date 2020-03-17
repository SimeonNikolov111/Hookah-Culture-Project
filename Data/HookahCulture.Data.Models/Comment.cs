namespace HookahCulture.Data.Models
{
    using HookahCulture.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Text { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
