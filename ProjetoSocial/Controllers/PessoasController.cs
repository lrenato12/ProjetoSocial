using System.Linq;
using System.Net;
using System.Web.Mvc;
using ProjetoSocial.Models;
using ProjetoSocial.Repository.Pessoa;

namespace ProjetoSocial.Controllers
{
    [Authorize]
    public class PessoasController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();
        private PessoaRepository repository;

        public ActionResult Index()
        {
            NewRepository();
            var pessoa = repository.GetPessoas();
            return View(pessoa.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Pessoa pessoa = repository.GetPessoaByID(id);
            if (pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }

        public ActionResult Create()
        {
            ViewBag.AnimaisAdotados = new SelectList(db.Animal, "Id", "Especie");
            ViewBag.Contato = new SelectList(db.Contato, "Id", "Telefone");
            ViewBag.Endereco = new SelectList(db.Endereco, "Id", "Logradouro");
            ViewBag.Login = new SelectList(db.Login, "Id", "Usuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataInclusao,Informacoes,Endereco,Contato,Login,AnimaisAdotados")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.InsertPessoa(pessoa);
                return RedirectToAction("Index");
            }

            ViewBag.AnimaisAdotados = new SelectList(db.Animal, "Id", "Especie", pessoa.AnimaisAdotados);
            ViewBag.Contato = new SelectList(db.Contato, "Id", "Telefone", pessoa.Contato);
            ViewBag.Endereco = new SelectList(db.Endereco, "Id", "Logradouro", pessoa.Endereco);
            ViewBag.Login = new SelectList(db.Login, "Id", "Usuario", pessoa.Login);
            return View(pessoa);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Pessoa pessoa = repository.GetPessoaByID(id);
            if (pessoa == null)
                return HttpNotFound();

            ViewBag.AnimaisAdotados = new SelectList(db.Animal, "Id", "Especie", pessoa.AnimaisAdotados);
            ViewBag.Contato = new SelectList(db.Contato, "Id", "Telefone", pessoa.Contato);
            ViewBag.Endereco = new SelectList(db.Endereco, "Id", "Logradouro", pessoa.Endereco);
            ViewBag.Login = new SelectList(db.Login, "Id", "Usuario", pessoa.Login);
            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataInclusao,Informacoes,Endereco,Contato,Login,AnimaisAdotados")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.UpdatePessoa(pessoa);
                return RedirectToAction("Index");
            }
            ViewBag.AnimaisAdotados = new SelectList(db.Animal, "Id", "Especie", pessoa.AnimaisAdotados);
            ViewBag.Contato = new SelectList(db.Contato, "Id", "Telefone", pessoa.Contato);
            ViewBag.Endereco = new SelectList(db.Endereco, "Id", "Logradouro", pessoa.Endereco);
            ViewBag.Login = new SelectList(db.Login, "Id", "Usuario", pessoa.Login);
            return View(pessoa);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Pessoa pessoa = repository.GetPessoaByID(id);
            if (pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewRepository();
            Pessoa pessoa = repository.GetPessoaByID(id);
            repository.DeletePessoa(pessoa.Id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private void NewRepository()
        {
            repository = new PessoaRepository(db);
        }
    }
}