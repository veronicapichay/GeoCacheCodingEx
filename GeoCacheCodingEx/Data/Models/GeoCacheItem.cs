using System;
using System.ComponentModel.DataAnnotations;

namespace GeoCacheCodingEx.Data.Models
{
    public class GeoCacheItem
    {


        public int GeocacheItemId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name must be 50 characters or shorter.")] //set limit on name field to 50 chars max.
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Name can only contain letters/numbers and spaces.")]
        public string GeocacheItemName { get; set; }
        public int GeocacheId { get; set; }
        public bool GeocacheItemIsActive { get; set; }
        public string GeocacheItemActiveDates { get; set; }


      
    }
}
