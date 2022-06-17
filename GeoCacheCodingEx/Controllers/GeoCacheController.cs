using GeoCacheCodingEx.Data;
using GeoCacheCodingEx.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        [HttpGet("/geocachin/allitems")]
        public async Task<IEnumerable<GeoCacheItem>> GetAllItems()
        {

            return await geocache.GeocacheItems.ToListAsync<GeoCacheItem>();

        }


        //get active list 
        [HttpGet("/geocahing/activeitems")]
        public async Task <IEnumerable<GeoCacheItem>> GetActiveItems()
        {
            
            return await geocache.GeocacheItems.Where(items => items.GeocacheItemIsActive).ToListAsync();

        }

       







    }
}
