using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GrupoPrazo_Infra.Repositorio;
using GrupoPrazo_Infra.Entidades;

namespace GrupoPrazoWeb.Controllers
{
    public class TarefasController : Controller
    {
        private readonly TarefaRepositorio _tarefaRepositorio;
        private readonly UsuarioRepositorio _usuarioRepositorio;
        public string local = "";
        // GET: Usuarios
        public TarefasController()
        {
            _tarefaRepositorio = new TarefaRepositorio();
            _usuarioRepositorio = new UsuarioRepositorio();

        }

        // GET: Tarefas

        public ActionResult Index()
        {
            return View(_tarefaRepositorio.ListarTarefas());
        }

        public ActionResult Index_Adm()
        {
            return View(_tarefaRepositorio.ListarTarefas());
        }
        // GET: Tarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = _tarefaRepositorio.RetornarTarefa(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Usuario,Descricao,Estado")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _tarefaRepositorio.Salvar(tarefa);
                if (Request.Cookies.Get("id_usuario") != null)
                {
                    int id = int.Parse(Request.Cookies.Get("id_usuario").Value);
                    
                    Usuario usuario = _usuarioRepositorio.RetornarUsuario(id);

                    switch (usuario.Permissao)
                    {
                        case "A":
                            local = "Index_Adm";
                            return RedirectToAction(local);
                        case "P":
                            local = "Index";
                            return RedirectToAction(local);
                        default:
                            ModelState.AddModelError("", "Login inválido.");
                            return View("Login");
                    }
                }
                
            }

            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = _tarefaRepositorio.RetornarTarefa(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Usuario,Descricao,Estado")] Tarefa tarefa)
        {

            if (ModelState.IsValid)
            {
                _tarefaRepositorio.Alterar(tarefa);

                if (Request.Cookies.Get("id_usuario") != null)
                {
                    int id = int.Parse(Request.Cookies.Get("id_usuario").Value);

                    Usuario usuario = _usuarioRepositorio.RetornarUsuario(id);

                    switch (usuario.Permissao)
                    {
                        case "A":
                            local = "Index_Adm";
                            return RedirectToAction(local);
                        case "P":
                            local = "Index";
                            return RedirectToAction(local);
                        default:
                            ModelState.AddModelError("", "Login inválido.");
                            return View("Login");
                    }
                }

            }
            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = _tarefaRepositorio.RetornarTarefa(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _tarefaRepositorio.Excluir(id);

            if (Request.Cookies.Get("id_usuario") != null)
            {
                 id = int.Parse(Request.Cookies.Get("id_usuario").Value);

                Usuario usuario = _usuarioRepositorio.RetornarUsuario(id);

                switch (usuario.Permissao)
                {
                    case "A":
                        local = "Index_Adm";
                        return RedirectToAction(local);
                    case "P":
                        local = "Index";
                        return RedirectToAction(local);
                    default:
                        ModelState.AddModelError("", "Login inválido.");
                        return View("Login");
                }
            }

            return RedirectToAction(local);
        }

    }
}
