using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.CrossCuttingConcerns.Caching;
using Toy.Core.CrossCuttingConcerns.Caching.Microsoft;
using Toy.Core.Utilities.IoC;

namespace Toy.Core.DependencyResolves
{
   public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
