using Microsoft.AspNetCore.Http;
using ObjectBD.Helpers;
using ObjectBD.ViewModels;
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
        public byte[] GetFile(string nameImangeRest)
        {           
            var client = new RestClient(FileHelper.Get_RestClient());
            var request = new RestRequest("File", Method.GET);
            request. AddQueryParameter("nameImangeRest", nameImangeRest);

            var response = client.Execute(request);
            var context = response.RawBytes;
            return context;
        }

        public void UploadFile([MaybeNull] IFormFile file)
        {
            if (file == null)
                return;

            var client = new RestClient(FileHelper.Get_RestClient());
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
