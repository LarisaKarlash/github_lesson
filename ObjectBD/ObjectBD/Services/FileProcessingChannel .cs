﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ObjectBD.Services
{
    public class FileProcessingChannel 
    {
        private Channel<IFormFile> _channel;

        public FileProcessingChannel()
        {
            _channel = Channel.CreateUnbounded<IFormFile>();
        }

        public async Task SetAsync(IFormFile file)
        {
            await _channel.Writer.WriteAsync(file);
        }

        //public IFormFile Read()
        //{
        //    IFormFile file;
        //    _channel.Reader.TryRead(out file);
        //    return file;
        //}


        public IAsyncEnumerable<IFormFile> GetAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }
    }
}
