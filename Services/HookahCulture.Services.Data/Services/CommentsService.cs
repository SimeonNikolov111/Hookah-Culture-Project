using HookahCulture.Data;
using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly ApplicationDbContext dbContext;

        public CommentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(ApplicationUser user, string userId, int postId, string text)
        {
            var comment = new Comment()
            {
                User = user,
                UserId = userId,
                PostId = postId,
                Text = text,
            };

            await this.dbContext.Comments.AddAsync(comment);

            await this.dbContext.SaveChangesAsync();
        }

        public void Delete(int commentId)
        {
            var comment = this.dbContext.Comments.Where(c => c.Id == commentId).FirstOrDefault();

            this.dbContext.Comments.Remove(comment);
            this.dbContext.SaveChanges();
        }
    }
}
