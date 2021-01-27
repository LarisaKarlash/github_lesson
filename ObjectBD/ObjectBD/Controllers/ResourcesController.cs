using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ObjectBD.Configurations;
using ObjectBD.Helpers;
using ObjectBD.Services;
using ObjectBD.ViewModels;
using RestSharp;
using System;

namespace ObjectBD.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly IRestEkzClient _restClient;
        private readonly FileProcessingChannel _channel;
        private readonly IMemoryCache _cache;
        private readonly FileConfiguration _configuration;

        public ResourcesController(
            IRestEkzClient restClient,
            IMemoryCache cache,
            FileProcessingChannel channel,
            IOptions<FileConfiguration> options)
        {
            _restClient = restClient;
            _cache = cache;
            _channel = channel;
            _configuration = options.Value;
        }

        [HttpGet]
        public IActionResult Image()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Image(ResourceImageViewModel resourceImage )
        {
            // Занесем значения Image из модели в string nameImange class Helper
            string form_nameImange = FileHelper.Get_nameImange(resourceImage);

            //Чистим cache
            var cacheKey = FileHelper.Get_CacheKey();
           _cache.Remove(cacheKey);

            return Get();//RedirectToAction("Index", "Home");
        }

        // Открываем файл изображения из Rest файла
        public FileContentResult Get()
        {
            var nameImangeRest = FileHelper.nameImange;

            var cacheKey = FileHelper.Get_CacheKey();
            var image = _cache.Get<byte[]>(cacheKey);

            if (image == null )
            {
                image = _restClient.GetFile(nameImangeRest);
                var memoryCacheEntry = new MemoryCacheEntryOptions();
                memoryCacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_configuration.TimeAll.Cache);
                memoryCacheEntry.SlidingExpiration = TimeSpan.FromHours(_configuration.TimeAll.Sliding);
                _cache.Set<byte[]>(cacheKey, image, memoryCacheEntry);
            }

            return new FileContentResult(image, FileHelper.Get_ImageType());
        }

        [HttpGet]
        public IActionResult Upload()
        {
            var viewModel = new ResourceUploadViewModel();
            viewModel.UploadStage = UploadStage.Upload;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Upload(ResourceUploadViewModel viewModel)
        {
            var entryOptions = new MemoryCacheEntryOptions();
            entryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_configuration.TimeAll.Cache);

            if (viewModel.File?.Length > 0)
            {
                _channel.SetAsync(viewModel.File);
                viewModel.File = null;
                viewModel.UploadStage = UploadStage.Comleted;
            }

            return View(viewModel);
        }
    }
}
