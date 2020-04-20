namespace HookahCulture.Web.Areas.Administration.Controllers
{
    using HookahCulture.Common;
    using HookahCulture.Data.Models;
    using HookahCulture.Services.Data;
    using HookahCulture.Web.Controllers;
    using HookahCulture.Web.ViewModels.Administration;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;


    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IAddUserToRoleService addUserToRoleService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<ApplicationRole> roleManager, IAddUserToRoleService addUserToRoleService, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.addUserToRoleService = addUserToRoleService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateRole()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                ApplicationRole role = new ApplicationRole()
                {
                    Name = viewModel.RoleName,
                };

                IdentityResult result = await this.roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return this.Redirect("/Home/Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        this.ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult AddRoleToUser()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserViewModel viewModel)
        {
            var user = this.addUserToRoleService.GetUser(viewModel.UserId);

            await this.userManager.AddToRoleAsync(user, viewModel.RoleName);

            return this.Redirect("/Home/Index");
        }
    }
}
