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
            long id = 10020;
            IEnumerable<Endereco> teste = enderecoServico.GetEnderecosByIdUsuario(id);
            var teste2 = "123";
            return View(teste); 
        }
    }
}