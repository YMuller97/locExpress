using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocExpressMobile.Models
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
