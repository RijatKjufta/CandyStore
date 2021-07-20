using Candystore.Data;
using Candystore.Entities;
using Candystore.Repository.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Repository
{
    public class ApetisaniRepository : IApetisaniRepository
    {
        private readonly DataContext _dataContext;

        public ApetisaniRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddApetisani(ApetisaniTypes apetisanitypes)
        {
            _dataContext.Apetisani.Add(apetisanitypes);
            _dataContext.SaveChanges();
        }
        public void DeleteApetisani(int apetisanitypesId)
        {
            ApetisaniTypes apetisanitypes = GetApetisaniById(apetisanitypesId);
            _dataContext.Apetisani.Remove(apetisanitypes);
            _dataContext.SaveChanges();
        }
        public void EditApetisani(ApetisaniTypes apetisanitypes)
        {
            _dataContext.Apetisani.Update(apetisanitypes);
            _dataContext.SaveChanges();
        }

        public IEnumerable<ApetisaniTypes> GetAllProduct()
        {
            var result = _dataContext.Apetisani.AsEnumerable();
            return result;
        }

        public ApetisaniTypes GetApetisaniById(int id)
        {
            var result = _dataContext.Apetisani.FirstOrDefault(x => x.ID == id);
            return result;
        }
    }
}
