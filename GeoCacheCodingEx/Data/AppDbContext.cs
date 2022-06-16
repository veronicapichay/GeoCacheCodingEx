using Microsoft.EntityFrameworkCore;
using GeoCacheCodingEx.Data.Models;

namespace GeoCacheCodingEx.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {
         

        }

        public DbSet <GeoCache> Geocaches { get; set; }
        public DbSet <GeoCacheItem> GeocacheItems { get; set; }

        //data seeding 
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Geocaches>().HasData(

              new GeoCache
              {
                  GeocacheId = 1,
                  GeocacheName = "The Famous Cache",
                  GeocacheLatitude = "37.8661",
                  GeocacheLongitude = "-122.300853"


              }

                );

            modelBuilder.Entity<GeoCacheItems>().HasData(

              new GeoCacheItem
              {
                  GeocacheItemId = 1,
                  GeocacheItemName = "Rubix Cube",
                  GeocacheId = 1,
                  GeocacheItemIsActive = true,
                  GeocacheItemActiveDates = "1/22/2022 - 2/2/2022",
                               
                               
              }
                 
                 );

        }


    }
}

