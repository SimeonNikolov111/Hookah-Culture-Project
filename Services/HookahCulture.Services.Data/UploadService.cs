using HookahCulture.Data;
using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public class UploadService : IUploadsService
    {
        private readonly ApplicationDbContext dbContext;

        public UploadService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task UploadProfilePicture(ApplicationUser user, string uniqueFileName)
        {
            user.ProfilePicturePath = uniqueFileName;
            await this.dbContext.SaveChangesAsync();
        }
    }
}
