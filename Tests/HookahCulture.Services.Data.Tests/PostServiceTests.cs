using HookahCulture.Data.Models;
using HookahCulture.Services.Data.Tests.Common;
using HookahCulture.Web.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HookahCulture.Services.Data.Tests
{
    public class PostServiceTests
    {
        //[Fact]
        //public void TestIfCorrectCountIsReturned()
        //{
        //    var context = InMemoryDbContextInitializer.InitializeContext();
        //    AutoMapperInitializer.InitializeMapper();

        //    PostsService postService = new PostsService(context);
        //    context.Posts.AddRange(this.PostSeeder());
        //    context.SaveChanges();

        //    var posts = postService.GetAllPosts<IndexViewModel>();

        //    int expectedCount = 2;

        //    Assert.Equal(expectedCount, posts.Count());
        //}


        [Fact]
        public void TestPostCreation()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            PostsService postService = new PostsService(context);

            postService.Create("Some text", "exmaplePath.jpg", "testId");

            int expectedCountAfterCreation = 1;

            Assert.Equal(expectedCountAfterCreation, context.Posts.Count());
        }

        [Fact]
        public void TestPostDelete()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            PostsService postService = new PostsService(context);

            var posts = this.PostSeeder();
            context.Posts.AddRange(posts);
            context.SaveChanges();

            var post = context.Posts.FirstOrDefault();

            postService.Delete(post.Id);

            bool expectedState = true;

            Assert.Equal(expectedState, post.IsDeleted);
        }

        [Fact]
        public void TestingGetCountOfPostsForSpecificUser()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            PostsService postService = new PostsService(context);

            context.Users.Add(this.GetUser());
            context.SaveChanges();

            int count = postService.GetCountOfPostsForSpecificUser("someID");

            Assert.Equal(2, count);
        }

        [Fact]
        public void TestingGetCountOfPosts() 
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            PostsService postService = new PostsService(context);

            context.Posts.AddRange(this.PostSeeder());
            context.SaveChanges();

            var countOfPosts = postService.GetCountOfPosts();

            Assert.Equal(2, countOfPosts);
        }

        [Fact]
        public void TestingGetRecentlyRegisteredUsers() 
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            PostsService postService = new PostsService(context);

            context.Users.Add(this.GetUser());
            context.SaveChanges();

            int userCount = postService.GetRecentlyRegisteredUsers().Count();

            Assert.Equal(1, userCount);
        }


        public ICollection<Post> PostSeeder()
        {
            var posts = new List<Post>();

            var post = new Post()
            {
                Id = 1,
                Text = "Hey this is my first post",
                ImagePath = "~/images/testPath.jpg",
                UserId = "someId",
                CreatedOn = new DateTime(2020, 04, 20),
                IsDeleted = false,
            };

            var post2 = new Post()
            {
                Id = 2,
                Text = "Hey this is my second post",
                ImagePath = "~/images/testPath2.jpg",
                UserId = "someId2",
                CreatedOn = new DateTime(2020, 04, 20),
                IsDeleted = false,
            };


            posts.Add(post);
            posts.Add(post2);

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
