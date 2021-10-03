using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class BicycleContext : DbContext
    {
        public DbSet<Bicycle> Bicycle { get; set; }
        public DbSet<Order> Orders { get; set; }
        public BicycleContext(DbContextOptions<BicycleContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
