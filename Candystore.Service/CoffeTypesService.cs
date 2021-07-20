using Candystore.Entities;
using Candystore.Repository.Interfaces;
using Candystore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service
{
    public class CoffeTypesService : ICoffeTypesService
    {
        private readonly ICoffeTypesRepository _coffeTypesRepository;

        public CoffeTypesService(ICoffeTypesRepository coffeTypesRepository)
        {
            _coffeTypesRepository = coffeTypesRepository;
        }

        public void Add(CoffeTypes coffetypes)
        {
            _coffeTypesRepository.AddCoffe(coffetypes);
        }

        public void Delete(int coffetypes)
        {
            _coffeTypesRepository.DeleteCoffe(coffetypes);
        }

        public void Edit(CoffeTypes coffetypes)
        {
            _coffeTypesRepository.EditCoffe(coffetypes);
        }

        public IEnumerable<CoffeTypes> GetAllCoffe()
        {
            var result = _coffeTypesRepository.GetAllCoffe();
            return result;
        }

        public CoffeTypes GetCoffeById(int id)
        {
            var result = _coffeTypesRepository.GetCoffeById(id);
            return result;
        }
    }
}
