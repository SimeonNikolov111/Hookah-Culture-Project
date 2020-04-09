namespace HookahCulture.Web.ViewModels.Comment
{
    using HookahCulture.Data.Models;
    using HookahCulture.Services.Mapping;

    public class CreateCommentInputViewModel : IMapFrom<Comment>
    {
        public int PostId { get; set; }

        public string Text { get; set; }
    }
}
