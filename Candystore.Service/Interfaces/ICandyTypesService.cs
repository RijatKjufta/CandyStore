using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service.Interfaces
{
   public interface ICandyTypesService
    {
        void Add(CandyTypes candytypes);
        void Edit(CandyTypes candytypes);
        void Delete(int candytypes);
       CandyTypes GetCandyById(int id);

        IEnumerable<CandyTypes> GetAllCandy();
    }
}
