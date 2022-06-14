using System;

namespace GeoCacheCodingEx.Data.Models
{
    public class GeoCacheItem
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual GeoCache GeoCache { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ActiveDates { get; set; }





    }
}
