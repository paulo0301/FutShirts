using Servicos.Tabelas;
using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutShirt.Areas.Usuarios.Controllers
{
    public class MinhaContaController : Controller
    {
        private EnderecoServico enderecoServico = new EnderecoServico();
        // GET: MinhaConta
        public ActionResult MeusDados()
        {
            return View();
        }

        public ActionResult MeusEnderecos()
        {
            int id = 10006;

            return View(enderecoServico.GetEnderecosByIdUsuario(id));
        }
    }
}