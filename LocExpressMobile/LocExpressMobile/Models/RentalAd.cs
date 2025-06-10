using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocExpressApi.Shared.Models
{
    [Table("rental_ads")]
    public class RentalAd
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("city")]
        public string? City { get; set; }

        [Column("post_code")]
        public string? PostCode { get; set; }

        [Column("surface")]
        public int Surface { get; set; }

        [Column("rooms_number")]
        public int RoomsNumber { get; set; }

        [Column("bedrooms_number")]
        public int BedroomsNumber { get; set; }

        [Column("rent")]
        public double Rent { get; set; }

        [Column("rental_charges")]
        public double RentalCharges { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("views_counter")]
        public int? ViewsCounter { get; set; }

        [Column("favorite_counter")]
        public int? FavoriteCounter { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("owner_id")]
        public int OwnerId { get; set; }

        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("energy_category_id")]
        public int EnergyCategoryId { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [NotMapped]
        public PropertyType Type { get; set; }
        [NotMapped]
        public ICollection<Picture> Pictures { get; set; }
        [NotMapped]
        public EnergyCategory EnergyCategory { get; set; }
        [NotMapped]
        public User Owner { get; set; }
        [NotMapped]
        public ICollection<User> IsFavoriteOf { get; set; }
    }
}
