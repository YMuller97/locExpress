using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocExpressApi.Shared.Models
{
    [Table("energy_categories")]
    public class EnergyCategory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("value")]
        public char Value { get; set; }
    }
}
