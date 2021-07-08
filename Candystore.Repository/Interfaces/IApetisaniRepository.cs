using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Repository.Interfaces
{
    public interface IApetisaniRepository
    {
        void AddApetisani(ApetisaniTypes apetisanitypes);

        void EditApetisani(ApetisaniTypes apetisanitypes);

        void DeleteApetisani(int apetisanitypesId);

        ApetisaniTypes GetApetisaniById(int id);

        IEnumerable<ApetisaniTypes> GetAllProduct();
    }
}
