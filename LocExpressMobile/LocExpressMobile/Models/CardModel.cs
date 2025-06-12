using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocExpressMobile.Models
{
    public class CardModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? City { get; set; }

        public string? PostCode { get; set; }

        public int Surface { get; set; }

        public int RoomsNumber { get; set; }

        public int BedroomsNumber { get; set; }

        public double Rent { get; set; }

        public string? Description { get; set; }

        public int OwnerId { get; set; }
        public int TypeId { get; set; }
        public int EnergyCategoryId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
