using HookahCulture.Data.Models;
using HookahCulture.Services.Data.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HookahCulture.Services.Data.Tests
{
    public class PostServiceTests
    {
        [Fact]
        public void TestIfCountIsCorrectWhenGettingPosts()
        {
            var posts = this.PostSeeder();

            int postsCount = posts.Count();

            int expectedCount = 2;

            Assert.Equal(expectedCount, postsCount);
        }

        [Fact]
        public void TestIfPostDataIsCorrect()
        {
            string exampleText = "Hey this is my first post";
            string exampleImagePath = "~/images/testPath.jpg";

            var postFromDatabase = this.PostSeeder().FirstOrDefault();

            Assert.Equal(exampleText, postFromDatabase.Text);
            Assert.Equal(exampleImagePath, postFromDatabase.ImagePath);
        }

        [Fact]
        public void TestIfUserIsHavingCorrectPostsCount()
        {
            var user = this.GetUser();

            int userPostsCount = user.Posts.Count();

            int expectedCount = 1;

            Assert.Equal(userPostsCount, expectedCount);
        }

        [Fact]
        public void TestIfCreateWorksSuccessfully() 
        {
            var context = InMemoryDbContextInitializer.InitializeContext();
            var user = this.GetUser();

            var post = new Post()
            {
                Text = "Hello",
                ImagePath = "examplePath",
                UserId = "someID",
                User = user,
            };

            int expectedPostCountInDb = 2;

            user.Posts.Add(post);
            context.SaveChanges();

            Assert.Equal(expectedPostCountInDb, user.Posts.Count());
        }

        [Fact]
        public void TestIfDeleteWorksCorrectly() 
        {
            var user = this.GetUser();

            var postToRemove = user.Posts.FirstOrDefault();
            postToRemove.IsDeleted = true;

            var expectedBoolWhenDeleted = true;

            Assert.Equal(expectedBoolWhenDeleted, postToRemove.IsDeleted);
        }

        public ICollection<Post> PostSeeder()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            var posts = new List<Post>();

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

            posts.Add(post);
            posts.Add(post2);

            context.Posts.AddRange(posts);
            context.SaveChanges();

            return posts;
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
