using Candystore.Entities;
using Candystore.Repository.Interfaces;
using Candystore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service
{
   public class ApetisaniService : IApetisaniService
    {
        private readonly IApetisaniRepository _apetisaniRepository;

        public ApetisaniService(IApetisaniRepository apetisaniRepository)
        {
            _apetisaniRepository = apetisaniRepository;
        }

        public void Add(ApetisaniTypes apetisani)
        {
            _apetisaniRepository.AddApetisani(apetisani);
        }

        public void Delete(int apetisaniID)
        {
            _apetisaniRepository.DeleteApetisani(apetisaniID);
          
        }

        public void Edit(ApetisaniTypes apetisani)
        {
            _apetisaniRepository.EditApetisani(apetisani);
        }

        public IEnumerable<ApetisaniTypes> GetAllProduct()
        {
            var result = _apetisaniRepository.GetAllProduct();
            return result;
        }

        public ApetisaniTypes GetApetisaniById(int id)
        {
            var result = _apetisaniRepository.GetApetisaniById(id);
            return result;
          
        }
    }
}
