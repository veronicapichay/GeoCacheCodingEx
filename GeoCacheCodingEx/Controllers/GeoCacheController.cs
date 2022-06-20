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

        public GeoCacheController (AppDbContext appdbcontext)
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
        public async Task <IEnumerable<GeoCacheItem>> GetActiveItems()
        {
            
            return await geocache.GeocacheItems.Where(items => items.GeocacheItemIsActive).ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<GeoCacheItem>> AddItem(GeoCacheItem geoCacheitem)
        {
            //checks for name's uniqueness
            if (IsUnique  (geoCacheitem.GeocacheItemName))
                return BadRequest("Item name already exist.");


            if ((await geocache.GeocacheItems.CountAsync(items => items.GeocacheItemId == geoCacheitem.GeocacheItemId)) < 3)
                geocache.GeocacheItems.Add(geoCacheitem);
            await geocache.SaveChangesAsync();

            return CreatedAtAction("GetActiveItems", new { id = geoCacheitem.GeocacheItemId }, geoCacheitem);
            //return Ok(geoCache);

        }

        //method to see if name is already exist 
        private bool IsUnique (string input)
        {
            return geocache.GeocacheItems.Any(name => string.Compare(input, name.GeocacheItemName, true) == 0);
        }




        //[HttpPut("{id}/update/{}")]
       


    }
}
