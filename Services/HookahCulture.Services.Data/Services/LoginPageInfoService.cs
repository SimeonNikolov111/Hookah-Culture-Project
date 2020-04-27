using HookahCulture.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HookahCulture.Services.Data
{
    public class LoginPageInfoService : ILoginPageInfoService
    {
        private readonly ApplicationDbContext dbContext;

        public LoginPageInfoService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int TotalUserCount()
        {
            return this.dbContext.Users.Count();
        }

        public int TotalPostsCount()
        {
            return this.dbContext.Posts.Count();
        }
    }
}
