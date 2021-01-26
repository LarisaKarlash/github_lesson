using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Services
{
    public interface IRestEkzClient
    {
        public byte[] GetFile();

        public void UploadFile(IFormFile file);
    }
}
