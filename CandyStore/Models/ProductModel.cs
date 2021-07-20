using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Models
{
    public class ProductModel
    {
          
        [Key]
        public int ID { get; set; }

        public string PhotoURL { get; set; }

        public string CandyTitle { get; set; }

        public double Price { get; set; }

        #region Wishlist Data
        public double WishlistTotalPriceCandy { get; set; }
        public double WishlistTotalPriceCoffe { get; set; }
        public double WishlistTotalPriceApetisani { get; set; }
        public double WishlistTotalPriceOfAllTables { get; set; }

        //public Tuple<CandyTypes,CoffeTypes,ApetisaniTypes> AllProductsFromWishlistByLoggedInUser { get; set; }

        public IEnumerable<CandyTypes> AllCandyFromWishlistByLoggedInUser { get; set; }
        public IEnumerable<CoffeTypes> AllCoffeFromWishlistByLoggedInUser { get; set; }
        public IEnumerable<ApetisaniTypes> AllApetisaniFromWishlistByLoggedInUser { get; set; }

        #endregion
        //public string ApetisaniProduct { get; set; }
        //public double price { get; set; }

        // Other Data
        //public Tuple<CandyTypes, CoffeTypes, ApetisaniTypes> AllProducts { get; set; }
        //public Tuple<CandyTypes, CoffeTypes, ApetisaniTypes> AllProductsFromWishlistByLoggedInUser { get; set; }
        //public Tuple<CandyTypes, CoffeTypes, ApetisaniTypes> AllProductsAddedToCartByLoggedInUser { get; set; }

    }
}

