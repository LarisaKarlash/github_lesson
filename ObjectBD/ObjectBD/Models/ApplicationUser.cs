using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Models
{
    public class ApplicationUser : IdentityUser
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
    }
}
