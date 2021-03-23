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

namespace FutShirt.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioServico usuarioServico = new UsuarioServico();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(usuarioServico.GetUsuariosByNome());
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
                    var checkEmail = usuarioServico.GetUsuariosByEmail().FirstOrDefault(e => e.Email == usuario.Email);
                    var checkCpf = usuarioServico.GetUsuariosByCpf().FirstOrDefault(e => e.Cpf == usuario.Cpf);
                    if (checkEmail == null && checkCpf == null)
                    {
                        #region Gerar código de ativação
                        Random random = new Random();
                        string numeroAleatorio = string.Empty;
                        for(int i = 0; i < 6; i++)
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
                        usuarioServico.SaveUsuario(usuario);
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
                return RedirectToAction("CreateStepTwo", "Usuario");
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

            var v = usuarioServico.GetUsuariosByEmail().Where(a => a.Email == login.Email).FirstOrDefault();
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
            Usuario UserCode = new Usuario();
            return View("CreateStepTwo", UserCode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStepTwo(Usuario usuario)
        {
            try
            {
                //usuario.CodigoAtivacao comparar com session["user"];
                Session[User] = usuario;
                return RedirectToAction("CreateStepThree", "Usuario");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateStepThree()
        {
            ViewBag.estados = new SelectList(new object[]
            {
                new {Name = "Acre", Value = "AC" },
                new {Name = "Alagoas", Value = "AL" },
                new {Name = "Amapá", Value = "AP" },
                new {Name = "Amazonas", Value = "AM" },
                new {Name = "Bahia", Value = "BA" },
                new {Name = "Ceará", Value = "CE" },
                new {Name = "Distrito Federal", Value = "DF" },
                new {Name = "Espírito Santo", Value = "ES" },
                new {Name = "Goiás", Value = "GO" },
                new {Name = "Maranhão", Value = "MA" },
                new {Name = "Mato Grosso", Value = "MT" },
                new {Name = "Mato Grosso do Sul", Value = "MS" },
                new {Name = "Minas Gerais", Value = "MG" },
                new {Name = "Pará", Value = "PA" },
                new {Name = "Paraná", Value = "PR" },
                new {Name = "Pernambuco", Value = "PE" },
                new {Name = "Piauí", Value = "PI" },
                new {Name = "Rio de Janeiro", Value = "RJ" },
                new {Name = "Rio Grande do Norte", Value = "RN" },
                new {Name = "Rio Grande do Sul", Value = "RS" },
                new {Name = "Rondônia", Value = "RO" },
                new {Name = "Roraima", Value = "RR" },
                new {Name = "Santa Catarina", Value = "SC" },
                new {Name = "São Paulo", Value = "SP" },
                new {Name = "Sergipe", Value = "SE" },    
                new {Name = "Tocantins", Value = "TO" },
            }, "Value", "Name");
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
