using GrupoPrazo_Infra.Entidades;
using GrupoPrazo_Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GrupoPrazoWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly UsuarioRepositorio _usuarioRepositorio;
        // GET: Usuarios
        public LoginController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }
        public ActionResult Login()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Validar(string nome, string senha)
        {
            if (nome == null || nome == "" && (senha == null || senha==""))
            {
                ModelState.AddModelError("", "Nome e Senha são obrigatórios.");
                return View("Login");
            }

            Usuario usuario = _usuarioRepositorio.RetornarUsuarioNome(nome);
            

            if (usuario != null)
            {
                if (Request.Cookies.Get("id_usuario") == null)
                {
                    HttpCookie cookie = new HttpCookie("id_usuario");
                    cookie.Path = "/";
                    // valor do usuário ou qual valor deseja guardar
                    cookie.Value = usuario.Id.ToString();
                    // tempo que ele expira está 10 minutos se pode colocar mais tempo. 
                    cookie.Expires = DateTime.Now.AddMinutes(10d);
                    // envia o cookie para HttpResponse, nesse momento ele criou e você pode utilizar nas diversas páginas.
                    Response.Cookies.Add(cookie);
                }

                switch (usuario.Permissao)
                {
                    case "A":
                        return RedirectToAction("Index", "Usuarios");
                    case "P":
                        return RedirectToAction("Index", "Tarefas");
                    default:
                        ModelState.AddModelError("", "Login inválido.");
                        return View("Login");
                }
            }
            return View("Login");
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
