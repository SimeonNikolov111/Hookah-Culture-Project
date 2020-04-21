using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public interface IGalleryVotesService
    {
        Task GalleryVoteAsync(int imageId, string userId, bool isUpVote);

        int GetGalleryUpVotes(int imageId);

        int GetGalleryDownVotes(int imageId);
    }
}
