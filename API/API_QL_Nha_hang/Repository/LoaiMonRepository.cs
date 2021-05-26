using API_QL_Nha_hang.IRepository;
using API_QL_Nha_hang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_QL_Nha_hang.Repository
{
    public class LoaiMonRepository : IRepository<LoaiMon>
    {
        private Data_Nha_hang context = new Data_Nha_hang();
        public void Add(LoaiMon item)
        {
            context.LoaiMons.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.LoaiMons.Remove(context.LoaiMons.FirstOrDefault(e => e.MaLoaiMon == id));
            context.SaveChanges();
        }

        public LoaiMon Get(int id)
        {
            return context.LoaiMons.FirstOrDefault(e => e.MaLoaiMon == id);
        }

        public List<LoaiMon> List()
        {
            return context.LoaiMons.ToList();
        }

        public void Update(LoaiMon item, int id)
        {
            LoaiMon loai = context.LoaiMons.Find(id);
            
        }
    }
}