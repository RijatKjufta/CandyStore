using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Repository.Interfaces
{
    public interface ICandyTypesRepository
    {
        void AddCandy(CandyTypes candytypes);
        void EditCandy(CandyTypes candytypes);
        void DeleteCandy(int candytypesId);
        CandyTypes GetCandyById(int id);

        IEnumerable<CandyTypes> GetAllCandies();
    }
}
