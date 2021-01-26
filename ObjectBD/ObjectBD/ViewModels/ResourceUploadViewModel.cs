using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.ViewModels
{
    public class ResourceUploadViewModel
    {
        public IFormFile File { get; set; }
        public UploadStage UploadStage { get; set; }
    }

    public enum UploadStage
    {
        Upload,
        Comleted
    }
}
