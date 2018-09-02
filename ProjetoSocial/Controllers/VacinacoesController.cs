using System.Net;
using System.Web.Mvc;
using ProjetoSocial.Models;
using ProjetoSocial.Repository.Vacinas;

namespace ProjetoSocial.Controllers
{
    [Authorize]
    public class VacinacoesController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();
        private VacinacaoRepository repository;
        
        public ActionResult Index()
        {
            NewRepository();
            return View(repository.GetVacinacaos());
        }
        
        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Vacinacao vacinacao = repository.GetVacinacaoByID(id);
            if (vacinacao == null)
                return HttpNotFound();
            return View(vacinacao);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Data,Informacoes")] Vacinacao vacinacao)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.InsertVacinacao(vacinacao);
                return RedirectToAction("Index");
            }

            return View(vacinacao);
        }
        
        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Vacinacao vacinacao = repository.GetVacinacaoByID(id);
            if (vacinacao == null)
                return HttpNotFound();

            return View(vacinacao);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Data,Informacoes")] Vacinacao vacinacao)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.UpdateVacinacao(vacinacao);
                return RedirectToAction("Index");
            }
            return View(vacinacao);
        }
        
        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Vacinacao vacinacao = repository.GetVacinacaoByID(id);
            if (vacinacao == null)
                return HttpNotFound();

            return View(vacinacao);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewRepository();
            Vacinacao vacinacao = repository.GetVacinacaoByID(id);
            repository.DeleteVacinacao(vacinacao.Id);
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
            repository = new VacinacaoRepository(db);
        }
    }
}