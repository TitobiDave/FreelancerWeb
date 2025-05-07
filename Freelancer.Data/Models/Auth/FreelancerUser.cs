using Freelancer.Data.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Data.Models.Auth
{
    public class FreelancerUser
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<ProgrammingSkill> skills { get; set; }
    }
}
