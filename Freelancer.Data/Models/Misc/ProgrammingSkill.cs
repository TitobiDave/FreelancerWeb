using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Data.Models.Misc
{
    public class ProgrammingSkill
    {
        public int Id { get; set; }

        public Languages language{  get; set; }

        public ExperienceLevel ExperienceLevel { get; set; }

    }
}
