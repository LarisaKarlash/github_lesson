using CountryZip.Configurations;
using CountryZip.Helpers;
using CountryZip.Services;
using CountryZip.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IRestZipClient _restClient;
        private readonly IMemoryCache _cache;
        private readonly FileConfiguration _configuration;

        public CountriesController(
            IRestZipClient restClient,
            IMemoryCache cache,
            IOptions<FileConfiguration> options
            )
        {
            _restClient = restClient;
            _cache = cache;
            _configuration = options.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CountriesViewModel countries)
        {
            // построим https по значениям модели в class Helper
            string nameHttp = FileHelper.Get_RestClientCountries(countries);

            //Чистим cache
            var cacheKey = FileHelper.Get_CacheKeyCountries();
            _cache.Remove(cacheKey);

            return Get();//RedirectToAction("Index", "Home");
        }

        //Открываем файл из Rest файла
        public FileContentResult Get()
        {
            // var nameImangeRest = FileHelper.nameImangeCountries;

            var cacheKey = FileHelper.Get_CacheKeyCountries();
            var file = _cache.Get<byte[]>(cacheKey);

            if (file == null)
            {
                file = _restClient.GetFileCountries();
                var memoryCacheEntry = new MemoryCacheEntryOptions();
                memoryCacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_configuration.TimeAll.Cache);
                memoryCacheEntry.SlidingExpiration = TimeSpan.FromHours(_configuration.TimeAll.Sliding);
                _cache.Set<byte[]>(cacheKey, file, memoryCacheEntry);
            }

            return new FileContentResult(file, FileHelper.Get_FileTypeCountries());
        }

    }
}
