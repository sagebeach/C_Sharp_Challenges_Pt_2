using FirstChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstChallenge.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var comicBooks = ComicBookModel.GetComicBooks();

            return View(comicBooks);
        }

        public ActionResult Detail(int id)
        {
            var comicBooks = ComicBookModel.GetComicBooks();
            var comic = comicBooks.FirstOrDefault(p => p.ComicBookId == id);
            return View(comic);
        }
    }
}