using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_QL_Nha_hang.IRepository
{
    public interface IRepository2<T>
    {
        List<T> List();
        T Get(string id);
        void Add(T item);
        void Delete(string id);
        void Update(T item, string id);
    }
}