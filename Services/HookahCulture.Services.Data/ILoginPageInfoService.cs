using System;
using System.Collections.Generic;
using System.Text;

namespace HookahCulture.Services.Data
{
    public interface ILoginPageInfoService
    {
        int TotalUserCount();

        int TotalPostsCount();
    }
}
