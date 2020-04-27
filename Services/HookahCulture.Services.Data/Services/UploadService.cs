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

        public async Task UploadCoverPhoto(ApplicationUser user, string uniqueFileName)
        {
            user.ProfileCoverPath = uniqueFileName;
            await this.dbContext.SaveChangesAsync();
        }

        public void UploadImageInGallery(ApplicationUser user, string uniqueFileName)
        {
            var image = new Image()
            {
                UserWhoUploaded = user.FirstName + " " + user.LastName,
                UserTimeLineId = user.TimelineId,
                ImagePath = uniqueFileName,
                IsApproved = false,
            };

            this.dbContext.Images.Add(image);
            this.dbContext.SaveChanges();
        }
    }
}
