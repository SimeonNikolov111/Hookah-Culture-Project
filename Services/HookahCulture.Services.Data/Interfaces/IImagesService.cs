using HookahCulture.Data.Models;
using HookahCulture.Web.ViewModels.Gallery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public interface IImagesService
    {
        IEnumerable<T> GetAllImages<T>();

        IEnumerable<T> GetAllImagesForAdminApproval<T>();

        void GetImageForApproval(int imageId);
    }
}
