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

        [HttpPost("/api/additems")]
        public async Task<ActionResult<GeoCache>> AddItem (GeoCache cache)
        {

            geocache.Geocaches.Add(cache);
            await geocache.SaveChangesAsync();
            return CreatedAtAction(nameof(GetActiveItems), new { id = cache.GeocacheId }, cache);


        }

        [HttpPut("{id}/move/{GeoCacheItemName}")]
        public async Task<IActionResult> MoveItem (int id, int geocacheId)
        {
            var item = geocache.GeocacheItems.Find(id);

            //checks if input id exists 
            if (item == null)
                return BadRequest("Cannot find Geocache item id.");

            //checks if item is currently active 
            if (item.GeocacheItemIsActive == false )  
                return BadRequest("Item must be active.");   

            var geoCache = geocache.Geocaches.Find(geocacheId);

            //checks if input id exists 
            if (geocache == null)
                return BadRequest("Geocache id does not exist.");

            //checks if geocache is currently full
            if ((await geocache.GeocacheItems.CountAsync(i => i.GeocacheId == geocacheId)) >= 3)
                return BadRequest("Please pick a different Geocache. This is currently full.");

            item.GeocacheId = geocacheId;
            await geocache.SaveChangesAsync();
            return Ok();
        }

        private bool IsUnique(string input)
        {
            return geocache.GeocacheItems.Any(items => string.Compare(input, items.GeocacheItemName, true) == 0);
        }


    }
}
