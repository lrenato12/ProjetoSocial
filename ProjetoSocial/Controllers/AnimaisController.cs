using System.Net;
using System.Web.Mvc;
using ProjetoSocial.Models;
using ProjetoSocial.Repository.Animal;

namespace ProjetoSocial.Controllers
{
    [Authorize]
    public class AnimaisController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();
        private AnimalRepository repository;

        public ActionResult Index()
        {
            NewRepository();
            return View(repository.GetAnimals());
        }
        
        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Animal animal = repository.GetAnimalByID(id);
            if (animal == null)
                return HttpNotFound();

            return View(animal);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome");
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Especie,Nome,Peso,Cor,Idade,DataInclusao,DataAdocao,DescricaoLocalEncontrado,Status,Informacoes,Vacinas")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.InsertAnimal(animal);
                return RedirectToAction("Index");
            }

            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome", animal.Vacinas);
            return View(animal);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Animal animal = repository.GetAnimalByID(id);
            if (animal == null)
                return HttpNotFound();

            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome", animal.Vacinas);
            return View(animal);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Especie,Nome,Peso,Cor,Idade,DataInclusao,DataAdocao,DescricaoLocalEncontrado,Status,Informacoes,Vacinas")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.UpdateAnimal(animal);
                return RedirectToAction("Index");
            }

            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome", animal.Vacinas);
            return View(animal);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Animal animal = repository.GetAnimalByID(id);
            if (animal == null)
                return HttpNotFound();

            return View(animal);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewRepository();
            Animal animal = repository.GetAnimalByID(id);

            repository.DeleteAnimal(animal.Id);
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
            repository = new AnimalRepository(db);
        }
    }
}