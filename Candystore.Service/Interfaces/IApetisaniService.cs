using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service.Interfaces
{
   public interface IApetisaniService
    {
        void Add(ApetisaniTypes apetisani);
        void Edit(ApetisaniTypes apetisani);
        void Delete(int apetisaniID);
        ApetisaniTypes GetApetisaniById(int id);

        IEnumerable<ApetisaniTypes> GetAllProduct();
    }
}
