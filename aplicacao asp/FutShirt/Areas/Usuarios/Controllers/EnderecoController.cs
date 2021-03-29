using System;
using Modelo.Tabelas;
using Servicos.Tabelas;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutShirt.Areas.Usuarios.Controllers
{
    public class EnderecoController : Controller
    {
        private EnderecoServico enderecoServico = new EnderecoServico();
        // GET: Usuarios/Endereco
        public ActionResult MeusEnderecos()
        {
            int id = 10008;
            IEnumerable<Endereco> teste = enderecoServico.GetEnderecosByIdUsuario(id);
            return View(teste);
        }
    }
}