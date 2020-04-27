using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HookahCulture.Web.ViewModels.Votes
{
    public class ImageVoteInputModel
    {
        [Required]
        public int ImageId { get; set; }

        [Required]
        public bool IsUpVote { get; set; }
    }
}
