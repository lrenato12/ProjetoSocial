using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetoSocial.Models;
using ProjetoSocial.Repository.Login;

namespace ProjetoSocial.Controllers
{
    
    public class LoginsController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();
        private LoginRepository repository = null;

        [Authorize]
        public ActionResult Index()
        {
            repository = new LoginRepository(db);
            return View(repository.GetLogins());
        }

        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Login login = repository.GetLoginByID(id);
            if (login == null)
                return HttpNotFound();

            return View(login);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usuario,Senha,Status,Informacoes")] Login login)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                Guid guid = Guid.NewGuid();
                login.Id = guid.ToString();
                repository.InsertLogin(login);
                return RedirectToAction("Index");
            }

            return View(login);
        }

        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Login login = repository.GetLoginByID(id);
            if (login == null)
                return HttpNotFound();
            return View(login);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario,Senha,Status,Informacoes")] Login login)
        {
            if (ModelState.IsValid)
            {
                NewRepository();
                repository.UpdateLogin(login);
                return RedirectToAction("Index");
            }
            return View(login);
        }

        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            NewRepository();
            Login login = repository.GetLoginByID(id);
            if (login == null)
                return HttpNotFound();

            return View(login);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewRepository();
            Login login = repository.GetLoginByID(id);
            repository.DeleteLogin(login.Id);
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
            repository = new LoginRepository(db);
        }
    }
}