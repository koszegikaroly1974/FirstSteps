using FirstSteps.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSteps
{
    public class FirstStepsDbContext : DbContext
    {
        public FirstStepsDbContext(DbContextOptions<FirstStepsDbContext> options) : base(options)
        {

        }

        public DbSet<Partner> Partners{ get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}
