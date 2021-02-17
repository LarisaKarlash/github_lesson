using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CountryZip.Models
{
    public class CountryZp
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string CountryAbbreviation { get; set; }

        [Required]
        public int CountryNsiId { get; set; }

        public virtual CountryNsi CountryNsi { get; set; }

        public virtual List<PlaceZp> PlacesZp { get; set; }
    }
}
