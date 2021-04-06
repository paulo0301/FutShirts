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
            if (ModelState.IsValid)
            {
                Usuario usuarioLogin = usuarioServico.GetUsuariosByEmail().Where(a => a.Email == login.Email).FirstOrDefault();
                if (usuarioLogin != null)
                {
                    if (usuarioLogin.ContaAtiva) { 
                        login.Senha = Crypto.Hash(login.Senha);
                        if (string.Compare(login.Senha, usuarioLogin.Senha) == 0)
                        {   
                            string perfil = "Cliente";
                            if (usuarioLogin.IsAdmin == true) perfil = "Gerente";
                            FormsAuthentication.SignOut();
                            var ticket = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1, login.Email, DateTime.Now, DateTime.Now.AddHours(12), false, perfil));
                            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticket);
                            Response.Cookies.Add(cookie);
                            Session["User"] = usuarioLogin;
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