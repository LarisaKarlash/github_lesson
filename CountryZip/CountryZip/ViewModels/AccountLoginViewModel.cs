using System.ComponentModel.DataAnnotations;

namespace CountryZip.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool SaveSession { get; set; }
    }
}
