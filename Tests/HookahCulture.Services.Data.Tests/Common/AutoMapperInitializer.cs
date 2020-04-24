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
        public static void InitMapper()
        {
            AutoMapperConfig.RegisterMappings(
               typeof(IndexViewModel).GetTypeInfo().Assembly,
               typeof(IndexPostViewModel).GetTypeInfo().Assembly);
        }
    }
}
