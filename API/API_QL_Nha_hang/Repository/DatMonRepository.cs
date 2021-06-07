using API_QL_Nha_hang.IRepository;
using API_QL_Nha_hang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_QL_Nha_hang.Repository
{
    public class DatMonRepository : IRepository<DatMon>
    {
        private Data_Nha_hang context = new Data_Nha_hang();
       
        public void Add(DatMon item)
        {
            context.DatMons.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.DatMons.Remove(context.DatMons.FirstOrDefault(e => e.MaDatMon == id));
            context.SaveChanges();
        }

        public DatMon Get(int id)
        {
            return context.DatMons.FirstOrDefault(e => e.MaDatMon == id);
        }

        public List<DatMon> List()
        {
            return context.DatMons.ToList();
        }

        public void Update(DatMon item, int id)
        {
            DatMon loai = context.DatMons.Find(id);

        }
    }
}