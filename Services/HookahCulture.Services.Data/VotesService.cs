namespace HookahCulture.Services.Data
{
    using HookahCulture.Data;
    using HookahCulture.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VotesService : IVotesService
    {
        private readonly ApplicationDbContext dbContext;

        public VotesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetDownVotes(int postId)
        {
            var votes = this.dbContext.Votes.Where(v => v.PostId == postId && v.Type.ToString() == "DownVote").Sum(x => (int)x.Type);
            return votes;
        }

        public int GetUpVotes(int postId)
        {
            var votes = this.dbContext.Votes.Where(v => v.PostId == postId && v.Type.ToString() == "UpVote").Sum(x => (int)x.Type);
            return votes;
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = this.dbContext.Votes.FirstOrDefault(v => v.PostId == postId && v.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PostId = postId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };
            }

            await this.dbContext.Votes.AddAsync(vote);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
