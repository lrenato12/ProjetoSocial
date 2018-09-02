using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjetoSocial.Models;
using ProjetoSocial.Repository.Animal;

namespace ProjetoSocial.Controllers
{
    [Authorize]
    public class PainelAdministrativoController : Controller
    {
        private ProjetoSocialEntities db = new ProjetoSocialEntities();
        private AnimalRepository repository;

        public ActionResult Index()
        {
            repository = new AnimalRepository(db);
            return View(repository.GetAnimals());
        }

        public ActionResult Signout()
        {
            EncerraSessao();
            return RedirectToAction("Index", "Home");
        }

        private void EncerraSessao()
        {
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Clear();
        }
    }
}