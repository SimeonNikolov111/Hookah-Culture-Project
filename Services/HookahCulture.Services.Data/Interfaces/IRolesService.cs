﻿using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HookahCulture.Services.Data
{
    public interface IRolesService
    {
        ApplicationUser GetUser(string userId);

        ICollection<ApplicationUser> GetAllUsers();
    }
}
