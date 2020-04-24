using ForumSystem.Services.Data;
using HookahCulture.Data.Models;
using HookahCulture.Services.Data.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HookahCulture.Services.Data.Tests
{
    public class VoteServiceTests
    {
        [Fact]
        public void TestGetUpVotes() 
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            var voteService = new VotesService(context);
            context.Posts.AddRange(this.PostSeeder());
            context.SaveChanges();

            var firstPost = context.Posts.FirstOrDefault();
            
            int voteCount = voteService.GetUpVotes(firstPost.Id);

            Assert.Equal(1, voteCount);
        }

        [Fact]
        public void TestGetDownVotes()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            var voteService = new VotesService(context);
            context.Posts.AddRange(this.PostSeeder());
            context.SaveChanges();

            var firstPost = context.Posts.FirstOrDefault();

            int voteCount = voteService.GetDownVotes(firstPost.Id);

            Assert.Equal(1, voteCount);
        }

        [Fact]
        public async Task TestVoting() 
        {
            var context = InMemoryDbContextInitializer.InitializeContext();

            var voteService = new VotesService(context);
            context.Posts.AddRange(this.PostSeeder());
            context.SaveChanges();

            await voteService.VoteAsync(2, "someId2", true);
            var upVotesCount = voteService.GetUpVotes(2);

            Assert.Equal(1, upVotesCount);
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

            var vote = new Vote() { Id = 1, IsUpVote = true, PostId = 1, CreatedOn = new DateTime(2020, 04, 18) };
            var vote2 = new Vote() { Id = 2, IsUpVote = false, PostId = 1, CreatedOn = new DateTime(2020, 04, 18) };

            post.Votes.Add(vote);
            post.Votes.Add(vote2);

            posts.Add(post);
            posts.Add(post2);

            return posts;
        }
    }
}
