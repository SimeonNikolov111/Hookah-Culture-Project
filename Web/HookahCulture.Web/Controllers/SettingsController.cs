﻿namespace HookahCulture.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HookahCulture.Data.Common.Repositories;
    using HookahCulture.Data.Models;
    using HookahCulture.Services.Data;
    using HookahCulture.Web.ViewModels.Settings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class SettingsController : BaseController
    {
        private readonly ISettingsService settingsService;

        private readonly IDeletableEntityRepository<Setting> repository;

        public SettingsController(ISettingsService settingsService, IDeletableEntityRepository<Setting> repository)
        {
            this.settingsService = settingsService;
            this.repository = repository;
        }


        [Authorize]
        public IActionResult Index()
        {
            var settings = this.settingsService.GetAll<SettingViewModel>();
            var model = new SettingsListViewModel { Settings = settings };
            return this.View(model);
        }


        [Authorize]
        public async Task<IActionResult> InsertSetting()
        {
            var random = new Random();
            var setting = new Setting { Name = $"Name_{random.Next()}", Value = $"Value_{random.Next()}" };

            await this.repository.AddAsync(setting);
            await this.repository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
