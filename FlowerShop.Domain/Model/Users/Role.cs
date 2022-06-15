using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Users
{
    public class Role: IdentityRole
    {
        public string Des { get; set; }
    }
}
