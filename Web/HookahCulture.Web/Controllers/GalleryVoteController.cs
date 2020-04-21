namespace HookahCulture.Web.Controllers
{
    using HookahCulture.Data.Models;
    using HookahCulture.Services.Data;
    using HookahCulture.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class GalleryVoteController : ControllerBase
    {
        private readonly IGalleryVotesService galleryVotesService;
        private readonly UserManager<ApplicationUser> userManager;

        public GalleryVoteController(IGalleryVotesService galleryVotesService, UserManager<ApplicationUser> userManager)
        {
            this.galleryVotesService = galleryVotesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Vote(ImageVoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.galleryVotesService.GalleryVoteAsync(input.ImageId, userId, input.IsUpVote);
            var upVotes = this.galleryVotesService.GetGalleryUpVotes(input.ImageId);
            var downVotes = this.galleryVotesService.GetGalleryDownVotes(input.ImageId);
            return new VoteResponseModel { UpVotes = upVotes, DownVotes = downVotes };
        }
    }
}
