using System.Net;
using System.Web.Mvc;
using ProjetoSocial.Models;
using ProjetoSocial.Repository.Endereco;

namespace ProjetoSocial.Controllers
{
    [Authorize]
    public class EnderecosController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();
        private EnderecoRepository repository;

        public ActionResult Index()
        {
            NewRepository();
            return View(repository.GetEnderecos());
        }
        
        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Endereco endereco = repository.GetEnderecoByID(id);
            if (endereco == null)
                return HttpNotFound();

            return View(endereco);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Logradouro,Numero,Bairro,Complemento,Cep,Municipio,Uf,Informacoes")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.InsertEndereco(endereco);
                return RedirectToAction("Index");
            }

            return View(endereco);
        }
        
        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Endereco endereco = repository.GetEnderecoByID(id);
            if (endereco == null)
                return HttpNotFound();

            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Logradouro,Numero,Bairro,Complemento,Cep,Municipio,Uf,Informacoes")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.UpdateEndereco(endereco);
                return RedirectToAction("Index");
            }
            return View(endereco);
        }
        
        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Endereco endereco = repository.GetEnderecoByID(id);
            if (endereco == null)
                return HttpNotFound();

            return View(endereco);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewRepository();
            Endereco endereco = repository.GetEnderecoByID(id);
            repository.DeleteEndereco(endereco.Id);
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
            repository = new EnderecoRepository(db);
        }
    }
}