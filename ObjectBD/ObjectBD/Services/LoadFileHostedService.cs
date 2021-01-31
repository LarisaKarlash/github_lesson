using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ObjectBD.Configurations;
using ObjectBD.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectBD.Services
{
    // открываем файл изображения из Rest файла в фоновом режиме
    public class LoadFileHostedService : BackgroundService
    {
        // private readonly IRestEkzClient _restClient;
        private readonly IServiceProvider _provider;
        private readonly IMemoryCache _cache;
        private readonly FileConfiguration _configuration;

        public LoadFileHostedService(
           // IRestEkzClient restClient, 
            IServiceProvider provider,
            IMemoryCache cache,
            IOptions<FileConfiguration> options)
        {
            // _restClient = restClient;
            _provider = provider;
            _cache = cache;
            _configuration = options.Value;
        }


        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                
                var scope = _provider.CreateScope();
                var _restClient = scope.ServiceProvider.GetRequiredService<IRestEkzClient>();

                var cacheKey = FileHelper.Get_CacheKey();
                var image = _cache.Get<byte[]>(cacheKey);

                if (image == null)
                {
                    image = _restClient.GetFile(FileHelper.Get_nameImangeRest());
                    var memoryCacheEntry = new MemoryCacheEntryOptions();
                    memoryCacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_configuration.TimeAll.Cache);
                    memoryCacheEntry.SlidingExpiration = TimeSpan.FromHours(_configuration.TimeAll.Sliding);
                    _cache.Set<byte[]>(cacheKey, image, memoryCacheEntry);
                }

                await Task.Delay(TimeSpan.FromMinutes(_configuration.TimeAll.Delay));
            }
        }
    }
}
