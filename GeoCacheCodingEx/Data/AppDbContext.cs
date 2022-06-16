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

            modelBuilder.Entity<GeoCache>().HasData(

              new GeoCache
              {
                  GeocacheId = 1,
                  GeocacheName = "The Famous Cache",
                  GeocacheLatitude = "37.8661",
                  GeocacheLongitude = "-122.300853"


              },

              new GeoCache
              {
                  GeocacheId = 2,
                  GeocacheName = "Find me if you can",
                  GeocacheLatitude = "35.3252449",
                  GeocacheLongitude = "-120.6975174"


              }
                );

            modelBuilder.Entity<GeoCacheItem>().HasData(

              new GeoCacheItem
              {
                  GeocacheItemId = 1,
                  GeocacheItemName = "Rubix Cube",
                  GeocacheId = 1,
                  GeocacheItemIsActive = true,
                  GeocacheItemActiveDates = "1/22/2022 - 6/29/2022",
                               
                               
              },
              new GeoCacheItem
              {
                   GeocacheItemId = 2,
                   GeocacheItemName = "Magic Cards",
                   GeocacheId = 1,
                   GeocacheItemIsActive = true,
                   GeocacheItemActiveDates = "1/22/2022 - 6/29/2022",


               },

              new GeoCacheItem
              {
                   GeocacheItemId = 3,
                   GeocacheItemName = "Speaker",
                   GeocacheId = 1,
                   GeocacheItemIsActive = false,
                   GeocacheItemActiveDates = "1/22/2022 - 4/1/2022",


              },
              new GeoCacheItem
              {
                   GeocacheItemId = 4,
                   GeocacheItemName = "Earplugs",
                   GeocacheId = 2,
                   GeocacheItemIsActive = false,
                   GeocacheItemActiveDates = "1/22/2022 - 2/1/2022",


               }
                 );

        }


    }
}

