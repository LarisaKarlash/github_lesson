using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CountryZip.Models
{
    public class CountryNsi
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string ExampleURL { get; set; }

        [Required]
        public string Range { get; set; }
        public virtual List<CountryZp> CountriesZp { get; set; }
    }
}
