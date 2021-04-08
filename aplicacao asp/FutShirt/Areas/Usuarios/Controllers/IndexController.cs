using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo.Tabelas;

namespace FutShirt.Areas.Usuarios.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}