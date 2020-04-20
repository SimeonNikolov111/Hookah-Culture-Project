using HookahCulture.Data;
using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HookahCulture.Services.Data
{
    public class AddUserToRoleService : IAddUserToRoleService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AddUserToRoleService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public ApplicationUser GetUser(string userId)
        {
            var user = this.applicationDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();

            return user;
        }
    }
}
