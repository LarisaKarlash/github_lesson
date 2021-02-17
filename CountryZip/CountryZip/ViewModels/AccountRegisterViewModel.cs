using System.ComponentModel.DataAnnotations;

namespace CountryZip.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Не совпадает с введенным паролем")]
        public string ConfirmPassword { get; set; }
    }
}
