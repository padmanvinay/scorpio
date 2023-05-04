using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using scorpio.Models;

namespace scorpio.Data
{
    public class ScorpioDbContext : DbContext
    {
        public ScorpioDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Provision> provision { get; set; }
        public DbSet<VesselAddedItem> VesselAddedItem { get; set; }
    }
}