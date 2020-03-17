namespace HookahCulture.Data.Seeding
{
    using HookahCulture.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PostSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Posts.Any())
            {
                return;
            }

            var allPosts = new List<Post>();

            var firstPost = new Post()
            {
                ImageUrl = "https://previews.123rf.com/images/burdun/burdun1812/burdun181200667/113849557-clay-shisha-bowl-with-craft-flawoured-tobacco-and-red-hot-coconut-coil-with-hookah-smoke-black-backg.jpg",
                Text = "This is my first post guys",
                Likes = 5,
            };

            var secondPosst = new Post()
            {
                ImageUrl = "https://www.albawaba.com/sites/default/files/styles/de2e_standard/public/im/shutterstock_610762706.jpg?itok=Sfveq68h",
                Text = "This is the second post",
                Likes = 3,
            };

            var thirdPost = new Post()
            {
                ImageUrl = "https://www.smoking-hookah.com/pub/media/catalog/product/cache/30a0c3bfe413e829e74c41f21caa91e5/l/u/lumos-hookah-glow.jpg",
                Text = "This is the second post",
                Likes = 8,
            };

            allPosts.Add(firstPost);
            allPosts.Add(secondPosst);
            allPosts.Add(thirdPost);

            await dbContext.Posts.AddRangeAsync(allPosts);
        }
    }
}
