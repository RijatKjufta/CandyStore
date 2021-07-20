using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candystore.Entities
{
  public  class ShoppingCart
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }

        public int CandyId { get; set; }
        public int CoffeId { get; set; }
        public int ApetisaniId { get; set; }
        public DateTime DateAdded { get; set; }

        public double Price { get; set; }
        public double PriceCandy { get; set; }
        public double PriceCoffe { get; set; }
        public double PriceApetisani { get; set; }

        public double Discount { get; set; }


    }
}
