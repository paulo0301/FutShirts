using FutShirt.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutShirt.Controllers
{
    public class CadastroController : Controller
    {
        private UsuarioContext usuarioContext = new UsuarioContext();
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cadastro Endereço
        public ActionResult ConfirmarCadastro()
        {
            return View();
        }

        // GET: Cadastrar Endereco
        public ActionResult CadastrarEndereco()
        {
            return View();
        }
    }
}