using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candystore.Entities
{
  public  class Order
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        public string ApetisaniProduct { get; set; }
        public string CoffeProduct { get; set; }
        public string CandyProduct { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string Apetisani { get; set; }
        public string Candy { get; set; }
        public string Coffe { get; set; }

    }
}
