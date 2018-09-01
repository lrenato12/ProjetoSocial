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
            repository = new AnimalRepository(db);
            return View(repository.GetAnimals());
        }
        
        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            repository = new AnimalRepository(db);
            Animal animal = repository.GetAnimalByID(id);
            if (animal == null)
                return HttpNotFound();

            return View(animal);
        }
        
        public ActionResult Create()
        {
            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Especie,Nome,Peso,Cor,Idade,DataInclusao,DataAdocao,DescricaoLocalEncontrado,Status,Informacoes,Vacinas")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                repository = new AnimalRepository(db);
                repository.InsertAnimal(animal);
                return RedirectToAction("Index");
            }

            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome", animal.Vacinas);
            return View(animal);
        }
        
        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            repository = new AnimalRepository(db);
            Animal animal = repository.GetAnimalByID(id);
            if (animal == null)
                return HttpNotFound();

            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome", animal.Vacinas);
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Especie,Nome,Peso,Cor,Idade,DataInclusao,DataAdocao,DescricaoLocalEncontrado,Status,Informacoes,Vacinas")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                repository = new AnimalRepository(db);
                repository.UpdateAnimal(animal);
                return RedirectToAction("Index");
            }

            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome", animal.Vacinas);
            return View(animal);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            repository = new AnimalRepository(db);
            Animal animal = repository.GetAnimalByID(id);
            if (animal == null)
                return HttpNotFound();

            return View(animal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            repository = new AnimalRepository(db);
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
    }
}