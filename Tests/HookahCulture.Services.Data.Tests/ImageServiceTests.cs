using HookahCulture.Data.Models;
using HookahCulture.Services.Data.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HookahCulture.Services.Data.Tests
{
    public class ImageServiceTests
    {
        [Fact]
        public void TestGetImageForApproval()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            ImageService imageService = new ImageService(context);

            var image = new Image() { Id = 1, IsApproved = false };
            context.Images.Add(image);
            context.SaveChanges();

            imageService.GetImageForApproval(image.Id);

            Assert.True(context.Images.FirstOrDefault().IsApproved);
        }
    }
}
