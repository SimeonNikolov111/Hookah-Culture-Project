using HookahCulture.Data.Models;
using HookahCulture.Services.Data.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HookahCulture.Services.Data.Tests
{
    public class CommentsService
    {
        [Fact]
        public void TestIfCommentIsCreatedSuccessully()
        {
            var user = this.GetUserWithPosts();

            string expectedCommentToAdd = "Hello";

            var firstPost = user.Posts.FirstOrDefault();
            firstPost.Comments.Add(new Comment { Text = "Hello", UserId = user.Id});

            Assert.Equal(expectedCommentToAdd, firstPost.Comments.FirstOrDefault().Text);
        }

        [Fact]
        public void TestingIfCommentIsRemovedSuccessfully()
        {
            var user = this.GetUserWithPosts();

            var getPost = user.Posts.FirstOrDefault();
            var comment = getPost.Comments.FirstOrDefault();
            getPost.Comments.Remove(comment);

            int expectedCommentsCount = 0;

            Assert.Equal(expectedCommentsCount, getPost.Comments.Count());
        }

        public ApplicationUser GetUserWithPosts()
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

            post.Comments.Add(new Comment { Text = "Hello", UserId = user.Id });

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
