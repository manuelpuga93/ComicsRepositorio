using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comics.Controllers
{
    public class ComicController : Controller
    {
        // GET: Comic
        public ActionResult CreateComic()
        {
            return PartialView("CreateComic");
        }

        public ActionResult ShowComics()
        {
            return PartialView("ShowComics");
        }

        public ActionResult EditComic()
        {
            return PartialView("EditComic");
        }
    }
}