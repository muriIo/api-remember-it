using System.ComponentModel.DataAnnotations;

namespace api_remember_it.DTOs
{
    public class AuthUserDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
