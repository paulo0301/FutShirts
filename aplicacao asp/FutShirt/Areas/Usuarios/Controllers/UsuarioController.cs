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
        public ActionResult MeusDados()
        {
            Usuario usuario = (Usuario)Session["User"];
            return View(usuarioServico.GetUsuarioById((long)usuario.Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioServico.SaveUsuario(usuario);
                    return RedirectToAction("MeusDados");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

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
