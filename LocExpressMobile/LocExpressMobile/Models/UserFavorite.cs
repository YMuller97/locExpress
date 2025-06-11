using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LocExpressMobile.Models
{
    [PrimaryKey(nameof(UserId), nameof(RentalAdId))]
    [Table("user_favorites")]
    public class UserFavorite
    {
        [ForeignKey(nameof(UserId))]
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey(nameof(RentalAdId))]
        [Column("rental_ad_id")]
        public int RentalAdId { get; set; }
    }
}
