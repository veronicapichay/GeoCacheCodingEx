using System.Collections.Generic;

namespace GeoCacheCodingEx.Data.Models
{
    public class GeoCache
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        
        public virtual ICollection<GeoCacheItem> Items { get; set; }





    }
}
