using Freelancer.Data.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Services.Services.Misc.Contract
{
    public interface ILanguage
    {
        public Task<List<Languages>> GetLanguages();
    }
}
