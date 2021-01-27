using ObjectBD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Helpers
{
    public static class FileHelper
    {
        public static string nameImange;

        public static string Get_CacheKey()
        {
            return $"image_{DateTime.UtcNow:yyyy_MM_dd}";
        }
        public static string Get_ImageType()
        {
            return "image/jpeg";
        }
        public static string Get_RestClient()
        {
            return "http://localhost:62537";
        }
        public static string Get_nameImange(ResourceImageViewModel resourceImage)
        {
           nameImange = resourceImage.ImageName;
           return nameImange;
        }
        public static string Get_nameImangeRest()
        {
            return "TerrainImage55";
        }

    }
}
