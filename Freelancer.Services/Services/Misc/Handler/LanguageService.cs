using Freelancer.Data.Models.Misc;
using Freelancer.Infrastructure;
using Freelancer.Services.Services.Misc.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Services.Services.Misc.Handler
{
    public class LanguageService : ILanguage
    {
        public readonly FreelancerDbContext _dbContext;

        public LanguageService(FreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Languages>> GetLanguages()
        {
            var result = await _dbContext.Languages.ToListAsync();

            return result;
        }
    }
}
