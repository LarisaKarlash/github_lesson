using CountryZip.Configurations;
using CountryZip.Helpers;
using CountryZip.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CountryZip.Services
{
    public class LoadFileHostedService : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly IMemoryCache _cache;
        private readonly FileConfiguration _configuration;

        public LoadFileHostedService(
            IServiceProvider provider,
            IMemoryCache cache,
            IOptions<FileConfiguration> options)
        {
            _provider = provider;
            _cache = cache;
            _configuration = options.Value;
        }


        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

                var scope = _provider.CreateScope();
                var _restClient = scope.ServiceProvider.GetRequiredService<IRestZipClient>();
                var _context = scope.ServiceProvider.GetRequiredService<ObjCountryDBContext>();

                CountryNsi countryNsis = new CountryNsi();
                var countries = _context.CountriesNsi.ToList();

                foreach (var obj in countries)
                {
                    var cacheKey = FileHelper.Get_CacheKeyCountriesCache(obj.Code);
                    var file = _cache.Get<byte[]>(cacheKey);

                    if (file == null)
                    {
                        file = _restClient.GetFileCountriesCache("https://" + obj.ExampleURL);

                        var memoryCacheEntry = new MemoryCacheEntryOptions();
                        memoryCacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_configuration.TimeAll.Cache);
                        memoryCacheEntry.SlidingExpiration = TimeSpan.FromHours(_configuration.TimeAll.Sliding);
                        _cache.Set<byte[]>(cacheKey, file, memoryCacheEntry);
                    }
                    break; // на время отладки
                }

                await Task.Delay(TimeSpan.FromMinutes(_configuration.TimeAll.Delay));

            }
        }
    }
}
