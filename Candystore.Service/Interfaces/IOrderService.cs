using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service.Interfaces
{
    public interface IOrderService
    {
        List<CandyTypes> ConvertAllItemsOfCandyInCartToList(IEnumerable<ShoppingCart> shoppings);
        List<CoffeTypes> ConvertAllItemsOfCoffeInCartToList(IEnumerable<ShoppingCart> shoppings);
        List<ApetisaniTypes> ConvertAllItemsOfApetisaniInCartToList(IEnumerable<ShoppingCart> shoppings);
        double CalculateTotalPriceCandy(List<CandyTypes> AllCandyListFromCart);
        double CalculateTotalPriceCoffe(List<CoffeTypes> AllCoffeListFromCart);
        double CalculateTotalPriceApetisani(List<ApetisaniTypes> AllApetisaniListFromCart);

        //Tuple<>
    }
}
