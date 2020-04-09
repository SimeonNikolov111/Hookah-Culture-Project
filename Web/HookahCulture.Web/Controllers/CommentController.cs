﻿using HookahCulture.Data.Models;
using HookahCulture.Services.Data;
using HookahCulture.Web.ViewModels.Comment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahCulture.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICommentsService commentsService;

        public CommentController(UserManager<ApplicationUser> userManager, ICommentsService commentsService)
        {
            this.userManager = userManager;
            this.commentsService = commentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentInputViewModel input)
        {
            if (string.IsNullOrEmpty(input.Text))
            {
                return this.NoContent();
            }
            else
            {
                var userId = this.userManager.GetUserId(this.User);
                var user = await this.userManager.GetUserAsync(this.User);
                await this.commentsService.Create(user, userId, input.PostId, input.Text);

                return this.Redirect("/");
            }
        }
    }
}