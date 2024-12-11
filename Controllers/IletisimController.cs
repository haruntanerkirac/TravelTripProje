using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MesajGonder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MesajGonder(FormCollection form)
        {

            var adSoyad = form["AdSoyad"];
            var mail = form["Mail"];
            var konu = form["Konu"];
            var mesaj = form["Mesaj"];

            var yollananMesaj = new Iletisim
            {
                AdSoyad = adSoyad,
                Mail = mail,
                Konu = konu,
                Mesaj = mesaj
            };

            context.Iletisims.Add(yollananMesaj);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}