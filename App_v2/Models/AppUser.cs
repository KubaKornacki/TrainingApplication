using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class AppUser: IdentityUser
    {

        public bool Sex { get; set; }

        public bool PlanExample { get; set; }
    }
}
