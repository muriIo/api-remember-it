using System.ComponentModel.DataAnnotations.Schema;

namespace api_remember_it.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("birthday")]
        public DateTime Birthday { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("profile_picture_url")]
        public string? ProfilePictureUrl { get; set; }
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}
