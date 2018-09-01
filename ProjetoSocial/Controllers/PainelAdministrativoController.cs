using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoSocial.Controllers
{
    [Authorize]
    public class PainelAdministrativoController : Controller
    {
        // GET: PainelAdministrativo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}