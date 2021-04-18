using Modelo.Tabelas;
using Servicos.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace FutShirt.Areas.Usuarios.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioServico usuarioServico = new UsuarioServico();
        [Authorize]
        public ActionResult MeusDados()
        {
            Usuario usuario = (Usuario)Session["User"];
            
            return View(usuarioServico.GetUsuarioById((long)usuario.Id));
        }
        public ActionResult EditarUsuario(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioServico.GetUsuarioById((long)id);
            ViewEditUsuario editUsuario = new ViewEditUsuario();
            if (usuario == null)
            {
                return HttpNotFound();
            }
            editUsuario.Usuario = usuario;
            return View(editUsuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditarUsuario(ViewEditUsuario editUsuario)
        {
            try
            {
                Usuario usuario = usuarioServico.GetUsuarioById((long)editUsuario.Usuario.Id);
                editUsuario.SenhaAntiga = Crypto.Hash(editUsuario.SenhaAntiga);
                if (editUsuario.SenhaAntiga == usuario.Senha)
                {
                    usuario = editUsuario.Usuario;
                    usuario.Senha = Crypto.Hash(editUsuario.SenhaNova);
                    usuario.ConfirmarSenha = Crypto.Hash(editUsuario.ConfirmarSenhaNova);
                    if (ModelState.IsValid)
                    {
                        usuarioServico.SaveUsuario(usuario);
                        return RedirectToAction("MeusDados");
                    }
                    else
                    {
                        return View(editUsuario);
                    }
                }
                else
                {
                    ModelState.AddModelError("SenhaAtualErrada", "● A senha digitada não confere com a senha atual");
                }
                return View(editUsuario);
            }
            catch (Exception excecao)
            {
                ViewBag.Error = excecao.Message;
                return View(editUsuario);
            }
        }

        [Authorize]
        public ActionResult DesativarConta(long? id)
        {
            try
            {
                var usuario = usuarioServico.GetUsuarioById((long)id);
                usuario.ContaAtiva = false;
                usuarioServico.SaveUsuario(usuario);
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
