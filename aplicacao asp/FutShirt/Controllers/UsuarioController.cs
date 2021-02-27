using FutShirt.Context;
using FutShirt.Models;
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

namespace FutShirt.Controllers
{
    public class UsuarioController : Controller
    {
        private EFContext usuarioContext = new EFContext();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(usuarioContext.Usuarios.OrderBy(c => c.Nome));
        }
        // GET: Usuario/Create
        public ActionResult CreateStepOne()
        {
            return View("CreateStepOne");
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStepOne([Bind(Exclude = "VerificacaoEmail, CodigoAtivacao")] Usuario usuario)
        {
            #region
            //try
            //{
            //    if (Session["User"] == null) { 
            //        Session["User"] = usuario;
            //    }
            //    return RedirectToAction("CreateStepTwo", "Usuario");
            //}
            #endregion
            try
            {
                bool Status = false;
                string mensagem = "";
                //Validação do modelo
                if (ModelState.IsValid)
                {
                    #region //Email existe
                    //var emailCheck = ChecarEmail(usuario.Email);
                    //if (emailCheck)
                    //{
                    //    ModelState.AddModelError("EmailExistente", "Email inserido já existe");
                    //    return View(usuario);
                    //}
                    #endregion

                    #region //Gerar código de ativação
                    //usuario.CodigoAtivacao = Guid.NewGuid();
                    #endregion

                    #region //Criptografia de senha
                    //usuario.Senha = Crypto.Hash(usuario.Senha);
                    //usuario.ConfirmarSenha = Crypto.Hash(usuario.ConfirmarSenha);
                    #endregion
                    //usuario.VerificacaoEmail = false;

                    #region //Salvar no banco de dados
                    usuarioContext.Usuarios.Add(usuario);
                    usuarioContext.SaveChanges();
                    #endregion

                    #region //Enviar email de validação
                    // EnviarEmail(usuario.Email, usuario.CodigoAtivacao.ToString());
                    //mensagem = "Conta registrada com sucesso. Um email de ativação foi enviada para você.";
                    //Status = true;
                    #endregion

                }
                else
                {
                    mensagem = "Requisição inválida.";
                }
                ViewBag.Message = mensagem;
                ViewBag.Status = Status;
                Session["User"] = usuario;
                return RedirectToAction("CreateStepTwo", "Usuario", Session["User"]);
            }
            catch
            {
                return View();
            }
        }

        //Login POST
        [HttpPost]
        public ActionResult Login(Usuario login)
        {
            string message = "";

            var v = usuarioContext.Usuarios.Where(a => a.Email == login.Email).FirstOrDefault();
            if (v != null)
            {
                if (string.Compare(login.Senha, v.Senha) == 0)
                {
                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    message = "E-mail ou senha inválida";
                }
            }
            else
            {
                message = "E-mail ou senha inválida";
            }


            ViewBag.Message = message;

            return View();
        }

        public ActionResult CreateStepTwo()
        {
                return View("CreateStepTwo", Session["User"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStepTwo(Usuario usuario)
        {
            try
            {
                Session["User"] = usuario;
                return RedirectToAction("CreateStepThree", "Usuario");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateStepThree()
        {
            return View("CreateStepThree", Session["User"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStepThree(Usuario usuario, Endereco endereco)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //Verificar conta
        
        

        //
        [NonAction]
        public bool ChecarEmail(string email)
        {
            var check = usuarioContext.Usuarios.Any(u => u.Email == email);
            if (check) return true;
            return false;
        }
        [NonAction]
        public void EnviarEmail(string email, string codigoAtivacao)
        {
            var VerificarUrl = "Usuario/VerificarConta" + codigoAtivacao;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, VerificarUrl);

            var fromEmail = new MailAddress("email@email.com.br", "FutShirt");
            var toEmail = new MailAddress(email);
            var fromPassword = "123";
            string subject = "Sua conta foi criada com sucesso";
            string body = "<br/><br/> Verifique sua conta: <a href='" + link + "'>"+ link +"<a/>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
                //Credentials = new NetworkCredential(fromEmail.Address, fromPassword)
            };

            var emailMensagem = new MailMessage(fromEmail, toEmail);
            emailMensagem.Subject = subject;
            emailMensagem.Body = body;
            emailMensagem.IsBodyHtml = true;
            smtp.Send(emailMensagem);

        }
    }
}
