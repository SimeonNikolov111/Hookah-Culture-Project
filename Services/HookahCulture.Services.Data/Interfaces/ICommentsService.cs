using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public interface ICommentsService
    {
        Task Create(ApplicationUser user,string userId, int postId, string text);

        void Delete(int commentId);
    }
}
