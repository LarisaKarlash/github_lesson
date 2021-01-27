using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.ViewModels
{
    public class ResourceImageViewModel
    {
        [Required]
        public string ImageName { get; set; }
    }
}
