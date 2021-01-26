using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Services
{
    public class RestEkzClient : IRestEkzClient
    {
        // открываем изображения из Rest файла
        public byte[] GetFile()
        {
            var client = new RestClient("http://localhost:62537");
            var request = new RestRequest("File", Method.GET);
            var response = client.Execute(request);
            var context = response.RawBytes;
            return context;
        }

        public void UploadFile([MaybeNull] IFormFile file)
        {
            if (file == null)
                return;

            var client = new RestClient("http://localhost:62537");
            var request = new RestRequest("File", Method.POST);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                request.AddJsonBody(Convert.ToBase64String(stream.ToArray()));
            }

            request.AddQueryParameter("fileName", file.FileName);
            var response = client.Execute(request);
        }
    }
}
