using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Data.Models.Auth
{
    public class Fuser: IdentityUser
    {
        public int Id {  get; set; }

        public FreelancerUser? FreelancerUser { get; set; }

        public Hirer? Hirer { get; set; }
    }
}
