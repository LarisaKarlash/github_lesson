using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ObjectBD.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Models
{
    public class IdentityDbContextPolzow :  IdentityDbContext<IdentityUserPolzow, IndentityRolePolzow, string>
    {
        public IdentityDbContextPolzow(DbContextOptions options)
        { 
        }
        protected IdentityDbContextPolzow()
        { 
        }
    }
}
