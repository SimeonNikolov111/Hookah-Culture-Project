namespace ForumSystem.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using HookahCulture.Data;
    using HookahCulture.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly ApplicationDbContext dbContext;

        public VotesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetUpVotes(int postId)
        {
            var votes = this.dbContext.Votes.Where(v => v.PostId == postId && v.IsUpVote == true).Count();

            return votes;
        }

        public int GetDownVotes(int postId)
        {
            var votes = this.dbContext.Votes.Where(v => v.PostId == postId && v.IsUpVote == false).Count();

            return votes;
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = this.dbContext.Votes.FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (vote != null)
            {
                if (isUpVote == true)
                {
                    vote.IsUpVote = true;
                }
                else if (isUpVote == false)
                {
                    vote.IsUpVote = false;
                }
            }
            else
            {
                vote = new Vote()
                {
                    PostId = postId,
                    UserId = userId,
                    IsUpVote = isUpVote,
                };

                await this.dbContext.Votes.AddAsync(vote);
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}