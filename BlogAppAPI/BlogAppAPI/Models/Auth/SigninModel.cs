using System.ComponentModel.DataAnnotations;

namespace BlogAppAPI.Models.Auth
{
    public class SigninModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
