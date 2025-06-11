using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocExpressMobile.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("FirstName")]
        public string? FirstName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("alias")]
        public string? Alias { get; set; }

        [Column("email_validated")]
        public bool EmailValidated { get; set; }

        [NotMapped]
        public ICollection<RentalAd> OwnedRentalAds { get; set; }
        [NotMapped]
        public ICollection<RentalAd> Favorites { get; set; }
    }
}