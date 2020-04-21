using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HookahCulture.Web.ViewModels.Administration
{
    public class RemoveRoleFromUserViewModel
    {
        public string RoleName { get; set; }

        public string UserId { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public ICollection<ApplicationRole> Roles { get; set; }
    }
}
