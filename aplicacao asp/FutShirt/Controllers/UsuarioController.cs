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

namespace FutShirt.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioContext usuarioContext = new UsuarioContext();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult CreateStepOne()
        {
            return View("~/Views/Usuario/cadastro_pessoal.cshtml");
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStepOne([Bind(Exclude = "VerificacaoEmail, CodigoAtivacao")] Usuario usuario)
        {
            //try
            //{
            //    if (Session["User"] == null) { 
            //        Session["User"] = usuario;
            //    }
            //    return RedirectToAction("CreateStepTwo", "Usuario");
            //}
            try
            {
                bool Status = false;
                string mensagem = "";
                //Validação do modelo
                if (ModelState.IsValid)
                {
                    #region //Email existe
                    var emailCheck = ChecarEmail(usuario.Email);
                    if (emailCheck)
                    {
                        ModelState.AddModelError("EmailExistente", "Email inserido já existe");
                        return View(usuario);
                    }
                    #endregion

                    #region //Gerar código de ativação
                    usuario.CodigoAtivacao = Guid.NewGuid();
                    #endregion

                    #region //Criptografia de senha
                    usuario.Senha = Crypto.Hash(usuario.Senha);
                    usuario.ConfirmarSenha = Crypto.Hash(usuario.ConfirmarSenha);
                    #endregion
                    usuario.VerificacaoEmail = false;

                    #region //Salvar no banco de dados
                    usuarioContext.Usuarios.Add(usuario);
                    usuarioContext.SaveChanges();
                    #endregion

                    #region //Enviar email de validação
                    EnviarEmail(usuario.Email, usuario.CodigoAtivacao.ToString());
                    mensagem = "Conta registrada com sucesso. Um email de ativação foi enviada para você.";
                    Status = true;
                    #endregion

                }
                else
                {
                    mensagem = "Requisição inválida.";
                }
                ViewBag.Message = mensagem;
                ViewBag.Status = Status;
                usuarioContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateStepTwo()
        {
                return View("~/Views/Usuario/confirmar_cadastro.cshtml", Session["User"]);
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
            return View("~/Views/Usuario/cadastro_endereco.cshtml", Session["User"]);
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
        [NonAction]
        public bool ChecarEmail(string email)
        {
            var check = usuarioContext.Usuarios.Where(u => u.Email == email).FirstOrDefault();
            return check != null;
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
