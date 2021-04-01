using Modelo.Tabelas;
using Servicos.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace FutShirt.Areas.Usuarios.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioServico usuarioServico = new UsuarioServico();
        private EnderecoServico enderecoServico = new EnderecoServico();


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(ViewLogin login, string returnUrl)
        {
            string message = "";

            Usuario v = usuarioServico.GetUsuariosByEmail().Where(a => a.Email == login.Email).FirstOrDefault();
            if (v != null)
            {
                if (v.ContaAtiva) { 
                    login.Senha = Crypto.Hash(login.Senha);
                    if (string.Compare(login.Senha, v.Senha) == 0)
                    {
                        FormsAuthentication.SetAuthCookie(login.Email, false);
                        Session["User"] = v;
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Index");
                        }
                    }
                    else
                    {
                        message = "E-mail ou senha inválida";
                    }
                }
                else
                {
                    message = "Conta desativada.";
                }
            }
            else
            {
                message = "E-mail ou senha inválida";
            }


            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Index");
        }
    }
}