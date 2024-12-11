using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog blog)
        {
            context.Blogs.Add(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var deger = context.Blogs.Find(id);
            context.Blogs.Remove(deger);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var blog = context.Blogs.Find(id);
            return View("BlogGetir",blog);
        }

        public ActionResult BlogGuncelle(Blog blog)
        {
            var deger = context.Blogs.Find(blog.ID);
            deger.Aciklama = blog.Aciklama;
            deger.Tarih = blog.Tarih;
            deger.Baslik = blog.Baslik;
            deger.BlogImage = blog.BlogImage;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var deger = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(deger);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult MesajGetir()
        {
            var mesajlar = context.Iletisims.ToList();
            return View(mesajlar);
        }

        public ActionResult MesajSil(int id)
        {
            var silinecekMesaj = context.Iletisims.Find(id);
            context.Iletisims.Remove(silinecekMesaj);
            context.SaveChanges();
            return RedirectToAction("MesajGetir");
        }

        public ActionResult HakkimizdaGetir()
        {
            var hakkimizda = context.Hakkimizdas.Find(1);
            return View(hakkimizda);
        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda hak)
        {
            var deger = context.Hakkimizdas.Find(1);
            deger.FotoUrl = hak.FotoUrl;
            deger.Aciklama = hak.Aciklama;
            context.SaveChanges();
            return RedirectToAction("HakkimizdaGetir");
        }
    }
}