using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutShirt.Areas.Usuarios.Controllers
{
    [Authorize(Roles="Gerente")]
    public class ProdutosController : Controller
    {
        // GET: Usuarios/Produtos
        public ActionResult ProdutosCadastrados()
        {
            return View();
        }
    }
}