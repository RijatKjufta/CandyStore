using Candystore.Entities;
using Candystore.Repository.Interfaces;
using Candystore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candystore.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICandyTypesRepository _candyTypesRepository;
        private readonly ICoffeTypesRepository _coffeTypesRepository;
        private readonly IApetisaniRepository _apetisaniRepository;

        public OrderService(IOrderRepository orderRepository, ICandyTypesRepository candyTypesRepository, ICoffeTypesRepository coffeTypesRepository, IApetisaniRepository apetisaniRepository)
        {
            _orderRepository = orderRepository;
            _candyTypesRepository = candyTypesRepository;
            _coffeTypesRepository = coffeTypesRepository;
            _apetisaniRepository = apetisaniRepository;
        }

        public double CalculateTotalPriceCandy(List<CandyTypes> AllCandyListFromCart)
        {
            var result = Math.Round(AllCandyListFromCart.Sum(x => x.price), 2);
            return result;
        }

        public double CalculateTotalPriceCoffe(List<CoffeTypes> AllCoffeListFromCart)
        {
            var result = Math.Round(AllCoffeListFromCart.Sum(x => x.Price), 2);
            return result;
        }

        public double CalculateTotalPriceApetisani(List<ApetisaniTypes> AllApetisaniListFromCart)
        {
            var result = Math.Round(AllApetisaniListFromCart.Sum(x => x.price), 2);
            return result;
        }

        public List<ApetisaniTypes> ConvertAllItemsOfApetisaniInCartToList(IEnumerable<ShoppingCart> shoppings)
        {
            List<ApetisaniTypes> allApetisaniListFromCartByLoggedInUser = new List<ApetisaniTypes>();

            foreach (var item in shoppings)
            {
                var apetisans = _apetisaniRepository.GetApetisaniById(item.ID);
                if (apetisans != null)
                {
                    allApetisaniListFromCartByLoggedInUser.Add(apetisans);
                }
            }

            return allApetisaniListFromCartByLoggedInUser;
        }

        public List<CandyTypes> ConvertAllItemsOfCandyInCartToList(IEnumerable<ShoppingCart> shoppings)
        {
            List<CandyTypes> allCandyListFromCartByLoggedInUser = new List<CandyTypes>();

            foreach (var item in shoppings)
            {
                var Candies =
                    _candyTypesRepository.GetCandyById(item.ID);
                if (Candies != null)
                {
                    allCandyListFromCartByLoggedInUser.Add(Candies);
                }
            }

            return allCandyListFromCartByLoggedInUser;
        }

        public List<CoffeTypes> ConvertAllItemsOfCoffeInCartToList(IEnumerable<ShoppingCart> shoppings)
        {
            List<CoffeTypes> allCoffeListFromCartByLoggedInUser = new List<CoffeTypes>();

            foreach (var item in shoppings)
            {
                var Coffee =
               _coffeTypesRepository.GetCoffeById(item.ID);
                if (Coffee != null)
                {
                    allCoffeListFromCartByLoggedInUser.Add(Coffee);
                }
            }

            return allCoffeListFromCartByLoggedInUser;
        }
    }
}
