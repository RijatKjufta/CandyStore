using Candystore.Entities;
using Candystore.Repository.Interfaces;
using Candystore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service
{
  public  class CandyTypesService : ICandyTypesService
    {
        private readonly ICandyTypesRepository _candyTypesRepository;

        public CandyTypesService(ICandyTypesRepository candyTypesRepository)
        {
            _candyTypesRepository = candyTypesRepository;
        }

        public void Add(CandyTypes candytypes)
        {
            _candyTypesRepository.AddCandy(candytypes);
        }

        public void Delete(int candytypesId)
        {
            _candyTypesRepository.DeleteCandy(candytypesId);
        }

        public void Edit(CandyTypes candytypes)
        {
            _candyTypesRepository.EditCandy(candytypes);
        }

        public IEnumerable<CandyTypes> GetAllCandy()
        {
           var result = _candyTypesRepository.GetAllCandies();
            return result;
        }

        public CandyTypes GetCandyById(int id)
        {
            var result = _candyTypesRepository.GetCandyById(id);
            return result;
        }
    }
}
