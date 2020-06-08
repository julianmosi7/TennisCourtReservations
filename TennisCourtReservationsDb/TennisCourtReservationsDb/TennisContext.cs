using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace TennisCourtReservationsDb
{
    public partial class TennisContext : DbContext
    {
        public TennisContext(DbContextOptions<TennisContext> options) : base(options) { }
        public TennisContext() { }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        private static TennisContext CreateContext()
        {
            var config = new ConfigurationBuilder()
                //.SetBasePath(AppContext.BaseDirectory)
                //.AddJsonFile("appsettings.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<TennisContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("TennisMdf"));
            var db = new TennisContext(optionsBuilder.Options);
            db.Database.Migrate();
            return db;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "data source=(LocalDB)\\mssqllocaldb; attachdbfilename=C:\\Temp\\Tennis.mdf; database=Tennis;integrated security=True; MultipleActiveResultSets=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
