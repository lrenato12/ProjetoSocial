using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoSocial.Models;

namespace ProjetoSocial.Controllers
{
    public class AnimaisController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();

        // GET: Animais
        public ActionResult Index()
        {
            var animal = db.Animal.Include(a => a.Vacinacao);
            return View(animal.ToList());
        }

        // GET: Animais/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animais/Create
        public ActionResult Create()
        {
            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome");
            return View();
        }

        // POST: Animais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Especie,Nome,Peso,Cor,Idade,DataInclusao,DataAdocao,DescricaoLocalEncontrado,Status,Informacoes,Vacinas")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animal.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome", animal.Vacinas);
            return View(animal);
        }

        // GET: Animais/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome", animal.Vacinas);
            return View(animal);
        }

        // POST: Animais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Especie,Nome,Peso,Cor,Idade,DataInclusao,DataAdocao,DescricaoLocalEncontrado,Status,Informacoes,Vacinas")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vacinas = new SelectList(db.Vacinacao, "Id", "Nome", animal.Vacinas);
            return View(animal);
        }

        // GET: Animais/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Animal animal = db.Animal.Find(id);
            db.Animal.Remove(animal);
            db.SaveChanges();
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
    }
}
