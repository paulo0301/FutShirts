using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutShirt.Controllers
{
    public class IndexController : Controller
    {
        // GET: Inde
        public ActionResult Index()
        {
            return View();
        }
    }
}