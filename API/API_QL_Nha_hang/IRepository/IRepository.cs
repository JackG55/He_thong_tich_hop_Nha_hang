using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_QL_Nha_hang.IRepository
{
    public interface IRepository<T>
    {
        List<T> List();
        T Get(int id);
        void Add(T item);
        void Delete(int id);
        void Update(T item, int id); 
    }
}