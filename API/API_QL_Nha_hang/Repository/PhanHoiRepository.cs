using API_QL_Nha_hang.IRepository;
using API_QL_Nha_hang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_QL_Nha_hang.Repository
{
    public class PhanHoiRepository : IRepository2<PhanHoi>
    {
        private Data_Nha_hang context = new Data_Nha_hang();
        public void Add(PhanHoi item)
        {
            context.PhanHois.Add(item);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            context.PhanHois.Remove(context.PhanHois.FirstOrDefault(e => e.MaPhanHoi == id));
            context.SaveChanges();
        }

        public PhanHoi Get(string id)
        {
            return context.PhanHois.FirstOrDefault(e => e.MaPhanHoi == id);
        }

        public List<PhanHoi> List()
        {
            return context.PhanHois.ToList();
        }

        public void Update(PhanHoi item, string id)
        {
            PhanHoi loai = context.PhanHois.Find(id);

        }
    }
}