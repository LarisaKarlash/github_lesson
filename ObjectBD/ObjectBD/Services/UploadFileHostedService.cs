using Microsoft.Extensions.Hosting;
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

        public UploadFileHostedService(IRestEkzClient restClient, FileProcessingChannel channel)
        {
            _restClient = restClient;
            _channel = channel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _restClient.UploadFile(_channel.Get());

                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}
