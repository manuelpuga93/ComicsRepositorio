using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comics.Controllers
{
    public class CompaniaController : Controller
    {
        // GET: Compania
        public ActionResult CreateCompania()
        {
            return PartialView("CreateCompania");
        }

        public ActionResult ShowCompanias()
        {
            return PartialView("ShowCompanias");
        }

        public ActionResult EditCompania()
        {
            return PartialView("EditCompania");
        }
    }
}