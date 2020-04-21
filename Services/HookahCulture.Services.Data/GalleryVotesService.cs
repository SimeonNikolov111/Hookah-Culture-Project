using HookahCulture.Data;
using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public class GalleryVotesService : IGalleryVotesService
    {
        private readonly ApplicationDbContext dbContext;

        public GalleryVotesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetGalleryUpVotes(int imageId)
        {
            var votes = this.dbContext.GalleryVotes.Where(v => v.ImageId == imageId && v.IsUpVote == true).Count();

            return votes;
        }

        public int GetGalleryDownVotes(int imageId)
        {
            var votes = this.dbContext.GalleryVotes.Where(v => v.ImageId == imageId && v.IsUpVote == false).Count();

            return votes;
        }

        public async Task GalleryVoteAsync(int imageId, string userId, bool isUpVote)
        {
            var vote = this.dbContext.GalleryVotes.FirstOrDefault(x => x.ImageId == imageId && x.UserId == userId);

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
                vote = new GalleryVote()
                {
                    ImageId = imageId,
                    UserId = userId,
                    IsUpVote = isUpVote,
                };

                await this.dbContext.GalleryVotes.AddAsync(vote);
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}
