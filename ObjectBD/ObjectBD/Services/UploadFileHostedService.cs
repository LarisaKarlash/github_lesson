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
        private IRestEkzClient _restClient { get; }
        private FileProcessingChannel _channel { get; }

        private readonly FileConfiguration _configuration;

        public UploadFileHostedService(
            IRestEkzClient restClient, 
            FileProcessingChannel channel,
            IOptions<FileConfiguration> options)
        {
            _restClient = restClient;
            _channel = channel;
            _configuration = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _restClient.UploadFile(_channel.Get());

                await Task.Delay(TimeSpan.FromSeconds(_configuration.TimeAll.DelayUpload));
            }
        }
    }
}
