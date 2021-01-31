using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ObjectBD.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectBD.Services
{
    public class UploadFileHostedService : BackgroundService
    {
        //private IRestEkzClient _restClient { get; }
        private FileProcessingChannel _channel { get; }

        private readonly FileConfiguration _configuration;
        private readonly IServiceProvider _provider;

        public UploadFileHostedService(
            //IRestEkzClient restClient, 
            IServiceProvider provider,
            FileProcessingChannel channel,
            IOptions<FileConfiguration> options)
        {
           // _restClient = restClient;
            _channel = channel;
            _configuration = options.Value;
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var scope = _provider.CreateScope();
                var _restClient = scope.ServiceProvider.GetRequiredService<IRestEkzClient>();

                await foreach (IFormFile file in _channel.GetAsync())
                {
                    if (file != null)
                    {
                        _restClient.UploadFile(file);
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(_configuration.TimeAll.DelayUpload));
            }

        }
    }
}
