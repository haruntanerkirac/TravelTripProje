using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context context = new Context();
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            //var bloglar = context.Blogs.ToList();
            by.Deger1 = context.Blogs.ToList();
            by.Deger2 = context.Yorumlars.OrderByDescending(x=>x.ID).Take(4).ToList();
            by.Deger3 = context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }

        public ActionResult BlogDetay(int id)
        {
            //var blogBul = context.Blogs.Where(x=>x.ID == id).ToList();
            by.Deger1 = context.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = context.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        /*
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yorum)
        {
            context.Yorumlars.Add(yorum);
            context.SaveChanges();
            return PartialView();
        }

        - Entity null dönüyor.
        */

        [HttpPost]
        public PartialViewResult YorumYap(FormCollection form)
        {
            var blogId = form["Blogid"];
            var kullaniciAdi = form["KullaniciAdi"];
            var mail = form["Mail"];
            var yorumMetni = form["Yorum"];

            //Debug.WriteLine($"BlogId: {blogId}, KullaniciAdi: {kullaniciAdi}, Mail: {mail}, Yorum: {yorumMetni}");

            var yorum = new Yorumlar
            {
                Blogid = int.Parse(blogId),
                KullaniciAdi = kullaniciAdi,
                Mail = mail,
                Yorum = yorumMetni
            };

            context.Yorumlars.Add(yorum);
            context.SaveChanges();

            return PartialView();
        }
    }
}