﻿using FutShirt.Context;
using FutShirt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult CreateStepOne(Usuario usuario)
        {
            try
            {
                if (Session["User"] == null) { 
                    Session["User"] = usuario;
                }
                return RedirectToAction("CreateStepTwo", "Usuario");
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
                usuarioContext.Usuarios.Add(usuario);
                usuarioContext.Enderecos.Add(endereco);
                usuarioContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
