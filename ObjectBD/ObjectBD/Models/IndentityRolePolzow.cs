using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Controllers
{
    public class IndentityRolePolzow : IdentityRole
    {
        public IndentityRolePolzow()
        { 
        }
        //
        // Сводка:
        //     Initializes a new instance of Microsoft.AspNetCore.Identity.IdentityRole.
        //
        // Параметры:
        //   roleName:
        //     The role name.
        //
        // Примечания:
        //     The Id property is initialized to form a new GUID string value.
        public IndentityRolePolzow(string roleName)
        { 
        }

    }
}
