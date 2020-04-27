using HookahCulture.Data;
using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public class RoleService : IRolesService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RoleService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public ApplicationUser GetUser(string userId)
        {
            var user = this.applicationDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();

            return user;
        }

        public ICollection<ApplicationUser> GetAllUsers()
        {
            var users = this.applicationDbContext.Users.ToList();

            return users;
        }
    }
}
