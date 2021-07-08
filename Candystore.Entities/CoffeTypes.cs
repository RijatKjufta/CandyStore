using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candystore.Entities
{
   public class CoffeTypes
    {
        [Key]

        public int ID { get; set; }

        public string CoffeProduct { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string imgURL { get; set; }





    }
}
