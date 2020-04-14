using HookahCulture.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HookahCulture.Data.Models
{
    public class UserPicture : BaseModel<int>
    {
        public string ProfilePicturePath { get; set; }

        public string ProfileCoverPath { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
