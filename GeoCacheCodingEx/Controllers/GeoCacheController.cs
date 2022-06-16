using GeoCacheCodingEx.Data;
using GeoCacheCodingEx.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet]
        public async Task <IEnumerable<GeoCacheItem>> GetGeoCacheItems()
        {

            return await geocache.GeocacheItems.ToListAsync<GeoCacheItem>();
            

        }



    }
}
