using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Services
{
    public interface IRestEkzClient
    {
        public byte[] GetFile(string nameImangeRest);

        public void UploadFile([NotNull]IFormFile file);
    }
}
