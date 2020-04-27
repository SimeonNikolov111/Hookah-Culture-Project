namespace HookahCulture.Web.ViewModels.Comment
{
    using HookahCulture.Data.Models;
    using HookahCulture.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CreateCommentInputViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public int PostId { get; set; }

        [MaxLength(250)]
        public string Text { get; set; }
    }
}
