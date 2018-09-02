using System.Net;
using System.Web.Mvc;
using ProjetoSocial.Models;
using ProjetoSocial.Repository.Contato;

namespace ProjetoSocial.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ContatosController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();
        private ContatoRepository repository;

        public ActionResult Index()
        {
            NewRepository();
            return View(repository.GetContatos());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Contato contato = repository.GetContatoByID(id);
            if (contato == null)
                return HttpNotFound();

            return View(contato);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Telefone,Celular,Email,Informacoes")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.InsertContato(contato);
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Contato contato = repository.GetContatoByID(id);
            if (contato == null)
                return HttpNotFound();

            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Telefone,Celular,Email,Informacoes")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.UpdateContato(contato);
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Contato contato = repository.GetContatoByID(id);
            if (contato == null)
                return HttpNotFound();

            return View(contato);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewRepository();
            Contato contato = repository.GetContatoByID(id);

            repository.DeleteContato(contato.Id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void NewRepository()
        {
            repository = new ContatoRepository(db);
        }
    }
}