using HookahCulture.Data.Models;
using HookahCulture.Services.Data.Tests.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HookahCulture.Services.Data.Tests
{
    public class CommentsServiceTests
    {
        [Fact]
        public async Task TestIfCommentIsCreatedSuccessully()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            var commentsService = new CommentsService(context);

            context.Comments.AddRange(this.CommentSeeder());
            context.SaveChanges();

            var comment = commentsService.Create(this.GetUser(), "userID", 1, "sometext");

            Assert.Equal(3, context.Comments.Count());
        }

        [Fact]
        public void TestingDelete()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            var commentsService = new CommentsService(context);

            context.Comments.AddRange(this.CommentSeeder());
            context.SaveChanges();

            int commentToRemove = context.Comments.FirstOrDefault().Id;

            commentsService.Delete(commentToRemove);

            Assert.Equal(1, context.Comments.Count());
        }

        public ICollection<Comment> CommentSeeder()
        {
            var firstComment = new Comment() { Text = "Nice One", UserId = "SomeId"};
            var secondComment = new Comment() { Text = "Nice Two", UserId = "SomeId" };

            List<Comment> comments = new List<Comment>();

            comments.Add(firstComment);
            comments.Add(secondComment);

            return comments;
        }

        public ApplicationUser GetUser()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            var user = new ApplicationUser()
            {
                Id = "someID",
                FirstName = "Simeon",
                LastName = "Nikolov",
                Email = "simeon@abv.bg",
                PasswordHash = "test",
            };

            context.Users.Add(user);

            var post = new Post()
            {
                Text = "Hey this is my first post",
                ImagePath = "~/images/testPath.jpg",
            };

            var post2 = new Post()
            {
                Text = "Hey this is my second post",
                ImagePath = "~/images/testPath2.jpg",
            };

            user.Posts.Add(post);
            user.Posts.Add(post2);
            context.SaveChanges();

            return user;
        }
    }
}
