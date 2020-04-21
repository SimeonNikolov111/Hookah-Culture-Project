using HookahCulture.Data;
using HookahCulture.Data.Models;
using HookahCulture.Services.Mapping;
using HookahCulture.Web.ViewModels.Gallery;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public class ImageService : IImagesService
    {
        private readonly ApplicationDbContext dbContext;

        public ImageService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<T> GetAllImages<T>()
        {
            var images = this.dbContext.Images.Where(i => i.IsApproved == false).To<T>().ToList();

            return images;
        }
    }
}
