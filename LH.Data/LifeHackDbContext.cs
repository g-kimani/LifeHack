using LH.Business.Events;
using LH.Business.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LH.Data
{
    public class LifeHackDbContext : DbContext
    {

        public LifeHackDbContext( DbContextOptions options ) : base( options )
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleEvent> ScheduleEvents { get; set; }
        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Event>().ToTable( "Events" );
            modelBuilder.Entity<ScheduleEvent>().ToTable( "ScheduleEvents" );
            modelBuilder.Entity<Schedule>().ToTable( "Schedules" );
        }
    }


    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LifeHackDbContext>
    {
        public LifeHackDbContext CreateDbContext( string[] args )
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath( Directory.GetCurrentDirectory() ).AddJsonFile( @Directory.GetCurrentDirectory() + "/../LifeHack/appsettings.json" ).Build();
            var builder = new DbContextOptionsBuilder<LifeHackDbContext>();
            var connectionString = configuration.GetConnectionString( "DefaultConnection" );
            builder.UseSqlServer( connectionString );
            return new LifeHackDbContext( builder.Options );
        }
    }

}
