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
    public class VacinacoesController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();

        // GET: Vacinacoes
        public ActionResult Index()
        {
            return View(db.Vacinacao.ToList());
        }

        // GET: Vacinacoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacinacao vacinacao = db.Vacinacao.Find(id);
            if (vacinacao == null)
            {
                return HttpNotFound();
            }
            return View(vacinacao);
        }

        // GET: Vacinacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacinacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Data,Informacoes")] Vacinacao vacinacao)
        {
            if (ModelState.IsValid)
            {
                db.Vacinacao.Add(vacinacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacinacao);
        }

        // GET: Vacinacoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacinacao vacinacao = db.Vacinacao.Find(id);
            if (vacinacao == null)
            {
                return HttpNotFound();
            }
            return View(vacinacao);
        }

        // POST: Vacinacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Data,Informacoes")] Vacinacao vacinacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacinacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacinacao);
        }

        // GET: Vacinacoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacinacao vacinacao = db.Vacinacao.Find(id);
            if (vacinacao == null)
            {
                return HttpNotFound();
            }
            return View(vacinacao);
        }

        // POST: Vacinacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vacinacao vacinacao = db.Vacinacao.Find(id);
            db.Vacinacao.Remove(vacinacao);
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
