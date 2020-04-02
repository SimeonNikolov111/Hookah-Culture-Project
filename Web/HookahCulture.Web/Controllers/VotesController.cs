namespace HookahCulture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HookahCulture.Data.Models;
    using HookahCulture.Services.Data;
    using HookahCulture.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVotesService votesService, UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        //Request body: {"postId":1, "isUpVote":true}
        //Response body {"votesCount": 16}
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.votesService.VoteAsync(input.PostId, userId, input.IsUpVote);
            var upVotes = this.votesService.GetUpVotes(input.PostId);
            var downVotes = this.votesService.GetDownVotes(input.PostId);
            return new VoteResponseModel { Likes = upVotes, Dislikes = downVotes };
        }
    }
}
