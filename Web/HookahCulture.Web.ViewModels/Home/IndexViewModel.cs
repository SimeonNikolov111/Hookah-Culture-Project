﻿namespace HookahCulture.Web.ViewModels.Home
{
    using HookahCulture.Data.Models;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexPostViewModel> Posts { get; set; }
    }
}
