using System.ComponentModel.DataAnnotations;

namespace ObjectBD.ViewModels
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
