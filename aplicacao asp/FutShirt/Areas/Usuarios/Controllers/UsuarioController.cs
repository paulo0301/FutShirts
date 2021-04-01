﻿using Modelo.Tabelas;
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
        private EnderecoServico enderecoServico = new EnderecoServico();
        
        // GET: Usuario
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(usuarioServico.GetUsuariosByNome());
        }
        // GET: Usuario/Create
        [AllowAnonymous]
        public ActionResult CreateStepOne()
        {
            return View("CreateStepOne");
        }
        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
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
                    var checkEmail = usuarioServico.GetUsuariosByEmail().FirstOrDefault(e => e.Email == usuario.Email);
                    var checkCpf = usuarioServico.GetUsuariosByCpf().FirstOrDefault(e => e.Cpf == usuario.Cpf);
                    if (checkEmail == null && checkCpf == null)
                    {
                        #region Gerar código de ativação
                        Random random = new Random();
                        string numeroAleatorio = string.Empty;
                        for (int i = 0; i < 6; i++)
                        {
                            numeroAleatorio += random.Next(0, 10).ToString();
                        }
                        usuario.CodigoAtivacao = numeroAleatorio;
                        #endregion

                        #region Criptografia de senha
                        usuario.Senha = Crypto.Hash(usuario.Senha);
                        usuario.ConfirmarSenha = Crypto.Hash(usuario.ConfirmarSenha);
                        #endregion

                        #region Validação de campos
                        usuario.Telefone = Regex.Replace(usuario.Telefone, @"[^0-9a-zA-Z]+", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
                        usuario.Cpf = Regex.Replace(usuario.Cpf, @"[^0-9a-zA-Z]+", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
                        #endregion

                        usuario.VerificacaoEmail = false;

                        #region Salvar no banco de dados
                        //usuarioServico.SaveUsuario(usuario);
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
                    return View();
                }
                ViewBag.Message = mensagem;
                ViewBag.Status = Status;
                Session["User"] = usuario;
                return RedirectToAction("CreateStepTwo", "Usuario");
            }
            catch
            {
                return View();
            }
        }
        

        [AllowAnonymous]
        public ActionResult CreateStepTwo()
        {
            Usuario UserCode = new Usuario();
            Usuario emailUser = (Usuario)Session["User"];
            UserCode.Email = emailUser.Email;
            
            return View("CreateStepTwo", UserCode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateStepTwo(Usuario usuario)
        {
            try
            {
                bool Status = false;
                string mensagem = "";

                //Validação do código de ativação
                Usuario u = (Usuario)Session["User"];
                if (u.CodigoAtivacao == usuario.CodigoAtivacao)
                {
                    mensagem = "Conta ativada com sucesso!";
                    u.VerificacaoEmail = true;
                    Status = true;
                }
                else
                {
                    mensagem = "Código de verificação inválido.";
                    ViewBag.Message = mensagem;
                    ViewBag.Status = Status;
                    ModelState.AddModelError("CodigoInvalido", "● Código inválido");
                    return View();
                }
                ViewBag.Message = mensagem;
                ViewBag.Status = Status;
                return RedirectToAction("CreateStepThree", "Usuario");
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult CreateStepThree()
        {
            return View("CreateStepThree");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateStepThree(Endereco endereco)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = (Usuario)Session["User"];
                    endereco.Usuario = usuario;
                    enderecoServico.SaveEndereco(endereco);
                }
                else
                {
                   return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(ViewLogin login, string returnUrl)
        {
            string message = "";

            Usuario v = usuarioServico.GetUsuariosByEmail().Where(a => a.Email == login.Email).FirstOrDefault();
            if (v != null)
            {
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
        //Verificar conta
        [NonAction]
        private void EnviarEmail(string email, string codigoAtivacao)
        {
            MailMessage _mailMessage = new MailMessage();

            _mailMessage.From = new MailAddress("futshirts0@gmail.com");


            _mailMessage.CC.Add(email);
            _mailMessage.Subject = "Código de ativação - FutShirts";
            _mailMessage.IsBodyHtml = true;
            _mailMessage.Body = "<h2>Seja bem vindo ao FutShirts</h2><p>Confirme seu email, seu código de ativação é <b>" + codigoAtivacao + "</b></p>";

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
