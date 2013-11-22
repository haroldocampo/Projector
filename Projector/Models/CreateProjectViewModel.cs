using Projector.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projector.Models {
    public class CreateProjectViewModel {
        public ProjectModel ProjectModel { get; set; }

        internal void ValidateFields(ProjectModel model, ModelStateDictionary modelState) {
            if (model.Name == "" || model.Name == null) {
                modelState.AddModelError("NameRequired", "Name is Required");
            }

            if (model.Code == "" || model.Code == null) {
                modelState.AddModelError("CodeRequired", "Code is Required");
            }

            if (model.Budget == 0) {
                modelState.AddModelError("BudgetRequired", "Budget is Required");
            }
        }

        internal void CreateProject(ProjectModel projectModel) {
            using (BasicDao context = new BasicDao()) {
                Project newProject = new Project();
                newProject.Name = projectModel.Name;
                newProject.Code = projectModel.Code;
                newProject.Budget = projectModel.Budget;
                newProject.Remarks = projectModel.Remarks;
                context.Insert(newProject);
            }
        }
    }
}