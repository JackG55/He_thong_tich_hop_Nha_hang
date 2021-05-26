using API_QL_Nha_hang.IRepository;
using API_QL_Nha_hang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_QL_Nha_hang.Repository
{
    public class BanRepository : IRepository2<Ban>
    {
        private Data_Nha_hang context = new Data_Nha_hang();
        public void Add(Ban item)
        {
            context.Bans.Add(item);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            context.Bans.Remove(context.Bans.FirstOrDefault(e => e.MaBan == id));
            context.SaveChanges();
        }

        public Ban Get(string id)
        {
            return context.Bans.FirstOrDefault(e => e.MaBan == id);
        }

        public List<Ban> List()
        {
            return context.Bans.ToList();
        }

        public void Update(Ban item, string id)
        {
            Ban loai = context.Bans.Find(id);

        }
    }
}