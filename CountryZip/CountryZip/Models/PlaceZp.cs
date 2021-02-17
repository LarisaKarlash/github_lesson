using System.ComponentModel.DataAnnotations;

namespace CountryZip.Models
{
    public class PlaceZp
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string PlaceName { get; set; }

        [Required]
        [RegularExpression("^[0-9.-]*$", ErrorMessage = "Поле должно быть цифровым, могут быть точки и - ")]
        public string Longitude { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string StateAbbreviation { get; set; }

        [Required]
        [RegularExpression("^[0-9.-]*$", ErrorMessage = "Поле должно быть цифровым, могут быть точки и - ")]
        public string Latitude { get; set; }

        [Required]
        public int CountryZpId { get; set; }

        public virtual CountryZp CountryZp { get; set; }
    }
}
