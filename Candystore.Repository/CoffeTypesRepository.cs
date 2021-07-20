using Candystore.Data;
using Candystore.Entities;
using Candystore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coffestore.Repository
{
   public class CoffeTypesRepository : ICoffeTypesRepository
    {
        private readonly DataContext _dataContext;

        public CoffeTypesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddCoffe(CoffeTypes CoffeTypes)
        {
            _dataContext.CoffeTypes.Add(CoffeTypes);
            _dataContext.SaveChanges();
        }
        public void DeleteCoffe(int CoffeTypesId)
        {
            CoffeTypes CoffeTypes = GetCoffeById(CoffeTypesId);
            _dataContext.CoffeTypes.Remove(CoffeTypes);
            _dataContext.SaveChanges();
        }
        public void EditCoffe(CoffeTypes CoffeTypes)
        {
            _dataContext.CoffeTypes.Update(CoffeTypes);
            _dataContext.SaveChanges();
        }

        public IEnumerable<CoffeTypes> GetAllCoffe()
        {
            var result = _dataContext.CoffeTypes.AsEnumerable();
            return result;
        }

        public CoffeTypes GetCoffeById(int id)
        {
            var result = _dataContext.CoffeTypes.FirstOrDefault(x => x.ID == id);
            return result;
        }
    }
}
