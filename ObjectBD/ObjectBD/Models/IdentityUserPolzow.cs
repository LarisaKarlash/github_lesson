using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Models
{
    public class IdentityUserPolzow : IdentityUser
    {
        
        //
        // Сводка:
        //     Initializes a new instance of Microsoft.AspNetCore.Identity.IdentityUser`1.
        public IdentityUserPolzow()
        { 
        }
        //
        // Сводка:
        //     Initializes a new instance of Microsoft.AspNetCore.Identity.IdentityUser`1.
        //
        // Параметры:
        //   userName:
        //     The user name.
        public IdentityUserPolzow(string userName)
        { 
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
    }
}
