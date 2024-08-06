using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_remember_it.Models
{
    [Table("user")]
    [Index(nameof(Id), nameof(Email), IsUnique = true)]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("email")]
        public string Email { get; set; } = string.Empty;
        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;
        [Column("password_salt")]
        public string PasswordSalt { get; set; } = string.Empty;
        [Column("birthday")]
        public DateTimeOffset Birthday { get; set; } = DateTimeOffset.Now;
        [Column("profile_picture_url")]
        public string? ProfilePictureUrl { get; set; }
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}
