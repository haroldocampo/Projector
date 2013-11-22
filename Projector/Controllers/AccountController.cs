using Projector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projector.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignIn() {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInModel model) {
            model.ValidateFields(model, ModelState);

            if (!ModelState.IsValid) {
                return View(model);
            }

            model.AuthenticateUser(Session, ModelState);

            if (!User.Identity.IsAuthenticated) {
                return View(model);
            }

            return RedirectToAction("Projects", "Home");
        }

    }
}
