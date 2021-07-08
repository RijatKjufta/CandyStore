using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candystore.Entities
{
   public class CandyTypes
    {
        [Key]
        public int ID { get; set; }

        public string CandyProduct { get; set; }

        public double price { get; set; }

        public string Description { get; set; }

        public string imgURL { get; set; }





    }
}
