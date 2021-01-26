using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        public ResourcesController(IRestEkzClient restClient, IMemoryCache cache, FileProcessingChannel channel)
        {
            _restClient = restClient;
            _cache = cache;
            _channel = channel;
        }

        // Открываем файл изображения из Rest файла
        public FileContentResult Get()
        {
            var cacheKey = $"image_{DateTime.UtcNow:yyyy_MM_dd}";
            var image = _cache.Get<byte[]>(cacheKey);

            if (image == null)
            {
                image = _restClient.GetFile();
                var memoryCacheEntry = new MemoryCacheEntryOptions();
                memoryCacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
                _cache.Set<byte[]>(cacheKey, image, memoryCacheEntry);
            }

            return new FileContentResult(image, "image/jpeg");
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
            entryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

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
