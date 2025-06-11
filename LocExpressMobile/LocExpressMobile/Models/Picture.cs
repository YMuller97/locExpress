using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocExpressMobile.Models
{
    [Table("pictures")]
    public class Picture
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [Column("rental_ad_id")]
        public int RentalAdId { get; set; }

        [NotMapped]
        public RentalAd RentalAd { get; set; }

    }
}
