using System;
using Modelo.Tabelas;
using Servicos.Tabelas;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutShirt.Areas.Usuarios.Controllers
{
    [Authorize]
    public class EnderecoController : Controller
    {
        private EnderecoServico enderecoServico = new EnderecoServico();
        // GET: Usuarios/Endereco
        public ActionResult MeusEnderecos()
        {
            Usuario usuario = (Usuario)Session["User"];
            return View(enderecoServico.GetEnderecosByIdUsuario(usuario.Id)); 
        }

        public ActionResult CreateEndereco()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEndereco(Endereco endereco)
        {
            return GravarEndereco(endereco);
        }

        public ActionResult EditEndereco(long Id)
        {
            Endereco endereco = enderecoServico.GetEnderecosById(Id);
            return View(endereco);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEndereco(Endereco endereco)
        {
            return GravarEndereco(endereco);
        }

        public ActionResult DeleteEndereco(long Id)
        {
            Endereco endereco = enderecoServico.GetEnderecosById(Id);
            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEnderecoP(long Id)
        {
            try { 
                enderecoServico.EliminarProdutoPorId(Id);
                return RedirectToAction("MeusEnderecos");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GravarEndereco(Endereco endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = (Usuario)Session["User"];
                    endereco.UsuarioId = usuario.Id;
                    enderecoServico.SaveEndereco(endereco);
                }
                else
                {
                    return View();
                }

                return RedirectToAction("MeusEnderecos");
            }
            catch
            {
                return View();
            }
        }
    }
}