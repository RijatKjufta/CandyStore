using Candystore.Data;
using Candystore.Entities;
using Candystore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candystore.Repository
{
   public class CandyTypesRepository : ICandyTypesRepository
    {
        private readonly DataContext _dataContext;

        public CandyTypesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddCandy(CandyTypes candytypes)
        {
            _dataContext.CandyTypes.Add(candytypes);
            _dataContext.SaveChanges();
        }
        public void DeleteCandy(int CandyTypesId)
        {
            CandyTypes CandyTypes = GetCandyById(CandyTypesId);
            _dataContext.CandyTypes.Remove(CandyTypes);
            _dataContext.SaveChanges();
        }
        public void EditCandy(CandyTypes CandyTypes)
        {
            _dataContext.CandyTypes.Update(CandyTypes);
            _dataContext.SaveChanges();
        }

        public IEnumerable<CandyTypes> GetAllCandies()
        {
            var result = _dataContext.CandyTypes.AsEnumerable();
            return result;
        }

        public CandyTypes GetCandyById(int id)
        {
            var result = _dataContext.CandyTypes.FirstOrDefault(x => x.ID == id);
            return result;
        }
    }
}
