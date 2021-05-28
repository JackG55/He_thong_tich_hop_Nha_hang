using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ClientWeb.Models;
using Newtonsoft.Json;

namespace ClientWeb.Controllers
{
    public class MenuController : Controller
    {
        private Model1 context = new Model1();
        // GET: Menu

        Repository repo = new Repository();

        public ActionResult Menu()
        {
            var json = repo.ReturnMessage("api/LoaiMon");
            var danh_muc = JsonConvert.DeserializeObject<List<LoaiMon>>(json);
            return View(danh_muc);
        }


        public ActionResult Mon_an(int maloaimon = 1)
        {
            var mon_an = context.MonAns.Where(x => x.MaLoaiMon == maloaimon).ToList();
            return PartialView("_PartialMon_an");
        }

        public ActionResult LayMonAn(int id)
        {
            repo._response = repo._client.GetAsync($"api/MonAn/{id}").Result;
            var json = repo._response.Content.ReadAsStringAsync().Result;
            var monan = JsonConvert.DeserializeObject<List<MonAn>>(json);
            return PartialView("_PartialMon_an", monan);
        }




    }
}