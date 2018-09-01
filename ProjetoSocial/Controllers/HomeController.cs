using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoSocial.Models;
using ProjetoSocial.Repository.Login;

namespace ProjetoSocial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string senha)
        {
            ProjetoSocialEntities objempcontext = new ProjetoSocialEntities();
            LoginRepository log = new LoginRepository(objempcontext);
            var vLogin = log.GetLoginByUserPass(usuario, senha);

            if (vLogin != null)
            {
                Session["Nome"] = vLogin.Usuario;
                Session["Status"] = vLogin.Status;
                return RedirectToAction("Index", "PainelAdministrativo");
            }
            else
            {
                ModelState.AddModelError("", "Usuário/Senha inválidos.");
                return View(new Login());
            }
        }
    }
}