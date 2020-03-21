﻿using HookahCulture.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HookahCulture.Services.Data
{
    public interface IPostsService
    {
        IEnumerable<T> GetAllPosts<T>();

        Task CreateAsync(string text, string imageUrl, string userId);
    }
}
