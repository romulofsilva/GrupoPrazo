using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using GrupoPrazo_Infra.Repositorio;
using GrupoPrazo_Infra.Entidades;

namespace GrupoPrazoWeb.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        // GET: Usuarios
        public UsuariosController ()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }
        public ActionResult Index()
        {
            return View(_usuarioRepositorio.ListarUsarios());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = _usuarioRepositorio.RetornarUsuario(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Permissao,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Salvar(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = _usuarioRepositorio.RetornarUsuario(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Permissao,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Alterar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = _usuarioRepositorio.RetornarUsuario(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _usuarioRepositorio.Excluir(id);
            return RedirectToAction("Index");
        }
        
    }
}
