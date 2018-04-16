using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comics.Controllers
{
    public class EscritorController : Controller
    {
        // GET: Escritor
        public ActionResult CreateEscritor()
        {
            return PartialView("CreateEscritor");
        }

        public ActionResult ShowEscritores()
        {
            return PartialView("ShowEscritores");
        }

        public ActionResult EditEscritor()
        {
            return PartialView("EditEscritor");
        }
    }
}