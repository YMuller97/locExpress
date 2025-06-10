using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocExpressApi.Shared.Models
{
    [Table("conversations")]
    public class Conversation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user1_id")]
        public int User1Id { get; set; }
        [Column("user2_id")]
        public int User2Id { get; set; }

        [Column("json_content", TypeName = "jsonb")]
        public string JsonContent { get; set; }

        [Column("last_message")]
        public string LastMessage { get; set; }

        [Column("rental_ad_id")]
        public int RentalAdId { get; set; }


        [NotMapped]
        public User User1 { get; set; }

        [NotMapped]
        public User User2 { get; set; }

        [NotMapped]
        public RentalAd RentalAd { get; set; }
    }
}
