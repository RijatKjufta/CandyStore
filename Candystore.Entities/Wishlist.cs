using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candystore.Entities
{
   public class Wishlist
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        public int CandyId { get; set; }
        public int CoffeId { get; set; }
        public int ApetisaniId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
