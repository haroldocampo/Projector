using Projector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projector.Controllers {

    [Authorize]
    public class HomeController : Controller {

        public ActionResult Projects() {
            ProjectsViewModel model = new ProjectsViewModel();
            model.PopulateProjects();
            return View(model);
        }

        public ActionResult CreateProject() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(CreateProjectViewModel model) {
            model.ValidateFields(model.ProjectModel, ModelState);

            if (!ModelState.IsValid) {
                return View(model);
            }

            model.CreateProject(model.ProjectModel);
            ViewBag.Message = String.Format("{0} has been created.", model.ProjectModel.Name);
            return View(model);
        }

        public ActionResult CreatePerson() {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePerson(CreatePersonViewModel model) {
            model.ValidateFields(model.PersonModel, ModelState);

            if (!ModelState.IsValid) {
                return View(model);
            }

            model.CreatePerson(model.PersonModel);
            ViewBag.Message = String.Format("{0} has been created.", model.PersonModel.Username);
            return View(model);
        }

        public ActionResult ProjectAssignments(int id) {
            ProjectAssignmentsViewModel model = new ProjectAssignmentsViewModel();
            model.PopulateData(id);
            return View(model);
        }
    }
}
