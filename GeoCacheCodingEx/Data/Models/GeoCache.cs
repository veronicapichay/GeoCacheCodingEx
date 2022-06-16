using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeoCacheCodingEx.Data.Models
{
    public class GeoCache
    {
        [Key]
        public int GeocacheId { get; set; }
        public string GeocacheName { get; set; }
        public string GeocacheLatitude { get; set; }
        public string GeocacheLongitude { get; set; }
        
        public virtual ICollection<GeoCacheItem> Items { get; set; }





    }
}
