using System;
using System.Collections.Generic;
using Enoca.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Enoca.DataAccess
{
	public class Context:DbContext
	{

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EnocaDb;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True");
        }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CarrierReport> CarrierReports { get; set; }
    }
}

