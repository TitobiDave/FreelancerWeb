﻿using Freelancer.Data.Models.Auth;
using Freelancer.Data.Models.Misc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Infrastructure
{
    public class FreelancerDbContext: IdentityDbContext
    {
        public FreelancerDbContext(DbContextOptions<FreelancerDbContext> options)
            :base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Fuser> fuser { get; set; }

        public DbSet<Languages> Languages { get; set; }
    }
}
