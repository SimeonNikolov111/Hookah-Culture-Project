using HookahCulture.Data.Models;
using HookahCulture.Services.Mapping;
using HookahCulture.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HookahCulture.Services.Data.Tests.Common
{
    public class AutoMapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
               typeof(IndexPostViewModel).GetTypeInfo().Assembly,
               typeof(Post).GetTypeInfo().Assembly);
        }
    }
}
