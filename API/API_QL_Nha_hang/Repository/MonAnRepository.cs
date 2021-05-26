using API_QL_Nha_hang.IRepository;
using API_QL_Nha_hang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_QL_Nha_hang.Repository
{
    public class MonAnRepository : IRepository<MonAn>
    {
        private Data_Nha_hang context = new Data_Nha_hang();
        public void Add(MonAn item)
        {
            context.MonAns.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.MonAns.Remove(context.MonAns.FirstOrDefault(e => e.MaMonAn == id));
            context.SaveChanges();
        }

        public MonAn Get(int id)
        {
            return context.MonAns.FirstOrDefault(e => e.MaLoaiMon == id);
        }

        public List<MonAn> List()
        {
            return context.MonAns.ToList();
        }

        public void Update(MonAn item, int id)
        {
            MonAn loai = context.MonAns.Find(id);

        }
    }
}