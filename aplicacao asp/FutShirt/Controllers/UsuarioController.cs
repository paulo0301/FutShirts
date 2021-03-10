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
                    var checkEmail = usuarioContext.Usuarios.FirstOrDefault(e => e.Email == usuario.Email);
                    var checkCpf = usuarioContext.Usuarios.FirstOrDefault(e => e.Cpf == usuario.Cpf);
                        if (checkEmail == null && checkCpf == null)
                    {
                        #region Gerar código de ativação
                        Random random = new Random();
                        string numeroAleatorio = string.Empty;
                        for(int i = 0; i < 6; i++)
                        {
                            numeroAleatorio += random.Next(1, 10).ToString();
                        }
                        usuario.CodigoAtivacao = numeroAleatorio;
                        #endregion

                        #region Criptografia de senha
                        usuario.Senha = Crypto.Hash(usuario.Senha);
                        usuario.ConfirmarSenha = Crypto.Hash(usuario.ConfirmarSenha);
                        #endregion

                        usuario.VerificacaoEmail = false;

                        #region Salvar no banco de dados
                        usuarioContext.Usuarios.Add(usuario);
                        usuarioContext.SaveChanges();
                        #endregion

                        #region Enviar email de validação
                        EnviarEmail(usuario.Email, usuario.CodigoAtivacao);
                        #endregion
                    }
                    else
                    {
                        if (checkEmail != null)
                        {
                            ModelState.AddModelError("EmailExistente", "● Email inserido já cadastrado");
                        }
                        if (checkCpf != null)
                        {
                            ModelState.AddModelError("CPFExistente", "● CPF inserido já cadastrado");
                        }
                        return View();
                    }
                    
                    
                   
                    mensagem = "Conta registrada com sucesso. Um email de ativação foi enviada para você.";
                    Status = true;
                    

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
        
                
        [NonAction]
        public void EnviarEmail(string email, string codigoAtivacao)
        {
            MailMessage _mailMessage = new MailMessage();
            
            _mailMessage.From = new MailAddress("futshirts0@gmail.com");


            _mailMessage.CC.Add(email);
            _mailMessage.Subject = "Código de ativação - FutShirts";
            _mailMessage.IsBodyHtml = true;
            _mailMessage.Body = "<h2>Seja bem vindo ao FutShirts</h2><p>Confirme seu email, seu código de ativação é <b>"+ codigoAtivacao +"</b></p>";

            //Configuração com porta
            SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

            //Credencial para envio por SMTP seguro
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential("futshirts0@gmail.com", "futinfoweb");

            _smtpClient.EnableSsl = true;

            _smtpClient.Send(_mailMessage);
        }
    }
}
