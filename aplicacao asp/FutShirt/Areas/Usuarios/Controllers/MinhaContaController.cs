using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutShirt.Areas.Usuarios.Controllers
{
    public class MinhaContaController : Controller
    {
        // GET: MinhaConta
        public ActionResult MeusDados()
        {
            return View();
        }
    }
}