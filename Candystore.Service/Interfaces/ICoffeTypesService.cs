using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service.Interfaces
{
   public interface ICoffeTypesService
    {
        void Add(CoffeTypes coffetypes);
        void Edit(CoffeTypes coffetypes);
        void Delete(int coffetypes);
    CoffeTypes GetCoffeById(int id);
        IEnumerable<CoffeTypes> GetAllCoffe();
    }
}
