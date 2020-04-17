using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public interface IUploadsService
    {
        Task UploadProfilePicture(ApplicationUser user, string uniqueFileName);

        Task UploadCoverPhoto(ApplicationUser user, string uniqueFileName);
    }
}
