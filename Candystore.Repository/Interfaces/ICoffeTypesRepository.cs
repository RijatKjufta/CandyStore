using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Repository.Interfaces
{
    public interface ICoffeTypesRepository
    {
        void AddCoffe(CoffeTypes coffetypes);
        void EditCoffe(CoffeTypes coffetypes);
        void DeleteCoffe(int coffetypesId);
        CoffeTypes GetCoffeById(int id);

        IEnumerable<CoffeTypes> GetAllCoffe();
    }
}
