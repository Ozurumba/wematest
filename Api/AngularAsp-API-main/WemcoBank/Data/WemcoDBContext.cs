using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemcoBank.Data
{
    public class WemcoDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public WemcoDBContext(DbContextOptions<WemcoDBContext> options) : base(options)
        { }

        public DbSet<OnBoarding> OnBoarding { get; set; }
        public DbSet<admState> admState { get; set; }
        public DbSet<admLGA> admLGA { get; set; }
    }
}
