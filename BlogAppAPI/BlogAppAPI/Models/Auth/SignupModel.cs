using System.ComponentModel.DataAnnotations;

namespace BlogAppAPI.Models.Auth
{
    public class SignupModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

    }
}
