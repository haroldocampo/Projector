using Projector.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projector.Models {
    public class ProjectsViewModel {
        public IEnumerable<ProjectModel> Projects;

        internal void PopulateProjects() {
            using (BasicDao context = new BasicDao()) {
                Projects = context.db.Projects.Select(x => new ProjectModel() { Id=x.Id, Name=x.Name, Budget=x.Budget }).ToList();
            }
        }
    }
}