using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ViewModels
{
    public class UserWithRole
    {

        public UserWithRole()
        {

            rolee = new List<string>();

        }


        public IdentityUser user { get; set; }
        public List<string> rolee { get;set; }
    }
}
