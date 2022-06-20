using GeoCacheCodingEx.Data;
using GeoCacheCodingEx.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace GeoCacheCodingEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoCacheController : ControllerBase
    {
        private AppDbContext geocache;

        public GeoCacheController(AppDbContext appdbcontext)
        {
            geocache = appdbcontext;


        }

        [HttpGet("/api/allitems")]
        public async Task<IEnumerable<GeoCacheItem>> GetAllItems()
        {

            return await geocache.GeocacheItems.ToListAsync<GeoCacheItem>();

        }


        //path to get active items  
        [HttpGet("/api/activeitems")]
        public async Task<IEnumerable<GeoCacheItem>> GetActiveItems()
        {

            return await geocache.GeocacheItems.Where(items => items.GeocacheItemIsActive).ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<GeoCache>> PostItem(GeoCache cache)
        {

            geocache.Geocaches.Add(cache);
            await geocache.SaveChangesAsync();
            return CreatedAtAction(nameof(GetActiveItems), new { id = cache.GeocacheId }, cache);




        }

















        //[HttpPut("{id}/update/{}")]
        //allow an item to be moved from one geocache to another.
        //Only active items should be allowed to be moved, and items cannot be moved to a geocache that already contains 3 or more items.



    }
}
