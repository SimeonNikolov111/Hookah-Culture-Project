﻿namespace HookahCulture.Web.Areas.Administration.Controllers
{
    using HookahCulture.Data.Models;
    using HookahCulture.Services.Data;
    using HookahCulture.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private static readonly RoleManager<ApplicationRole> roleManager;
        private static UserManager<ApplicationUser> addUserToRoleService;
        private static IRolesService userManager;
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
            : base(roleManager, userManager, addUserToRoleService)
        {
            this.settingsService = settingsService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }
    }
}
