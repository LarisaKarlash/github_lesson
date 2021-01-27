using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestExz.Controllers
{
    public class FileController
    {
        [HttpGet("File")]
        public FileContentResult Get([FromQuery]string nameImangeRest)
        {
            if (String.IsNullOrEmpty(nameImangeRest))
            {
                nameImangeRest = "TerrainImage55";
            }

            string path = "wwwroot/" + nameImangeRest + ".jpg";

            if (System.IO.File.Exists(path))
            {
                var fileBytes = System.IO.File.ReadAllBytes(path);
                return new FileContentResult(fileBytes, "image/jpeg");
            }
            else 
            {
                return null;
            }
           
        }

        [HttpPost("File")]
        public void UploadFile([FromBody] string file, [FromQuery] string fileName, [FromServices] IWebHostEnvironment webHost)
        {
            var filePath = Path.Combine(webHost.WebRootPath, fileName);
            var fileContent = Convert.FromBase64String(file);
            System.IO.File.WriteAllBytes(filePath, fileContent);
        }
    }
}
