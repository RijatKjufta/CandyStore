using Candystore.Data;
using Candystore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
