using System.ComponentModel.DataAnnotations;

namespace CountryZip.ViewModels
{
    public class CountriesViewModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Range { get; set; }
    }
}
