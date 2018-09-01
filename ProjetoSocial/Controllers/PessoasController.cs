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
    [Authorize]
    public class PessoasController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();

        // GET: Pessoas
        public ActionResult Index()
        {
            var pessoa = db.Pessoa.Include(p => p.Animal).Include(p => p.Contato1).Include(p => p.Endereco1).Include(p => p.Login1);
            return View(pessoa.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            ViewBag.AnimaisAdotados = new SelectList(db.Animal, "Id", "Especie");
            ViewBag.Contato = new SelectList(db.Contato, "Id", "Telefone");
            ViewBag.Endereco = new SelectList(db.Endereco, "Id", "Logradouro");
            ViewBag.Login = new SelectList(db.Login, "Id", "Usuario");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataInclusao,Informacoes,Endereco,Contato,Login,AnimaisAdotados")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Pessoa.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimaisAdotados = new SelectList(db.Animal, "Id", "Especie", pessoa.AnimaisAdotados);
            ViewBag.Contato = new SelectList(db.Contato, "Id", "Telefone", pessoa.Contato);
            ViewBag.Endereco = new SelectList(db.Endereco, "Id", "Logradouro", pessoa.Endereco);
            ViewBag.Login = new SelectList(db.Login, "Id", "Usuario", pessoa.Login);
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimaisAdotados = new SelectList(db.Animal, "Id", "Especie", pessoa.AnimaisAdotados);
            ViewBag.Contato = new SelectList(db.Contato, "Id", "Telefone", pessoa.Contato);
            ViewBag.Endereco = new SelectList(db.Endereco, "Id", "Logradouro", pessoa.Endereco);
            ViewBag.Login = new SelectList(db.Login, "Id", "Usuario", pessoa.Login);
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataInclusao,Informacoes,Endereco,Contato,Login,AnimaisAdotados")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimaisAdotados = new SelectList(db.Animal, "Id", "Especie", pessoa.AnimaisAdotados);
            ViewBag.Contato = new SelectList(db.Contato, "Id", "Telefone", pessoa.Contato);
            ViewBag.Endereco = new SelectList(db.Endereco, "Id", "Logradouro", pessoa.Endereco);
            ViewBag.Login = new SelectList(db.Login, "Id", "Usuario", pessoa.Login);
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pessoa pessoa = db.Pessoa.Find(id);
            db.Pessoa.Remove(pessoa);
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
