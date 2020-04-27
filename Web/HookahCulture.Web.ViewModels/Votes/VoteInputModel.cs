using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HookahCulture.Web.ViewModels.Votes
{
    public class VoteInputModel
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public bool IsUpVote { get; set; }
    }
}
