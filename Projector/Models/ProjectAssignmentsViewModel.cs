using Projector.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projector.Models {
    public class ProjectAssignmentsViewModel {
        public IEnumerable<PersonModel> AssignedPersons { get; set; }
        public IEnumerable<PersonModel> AllPersons { get; set; }
        public IEnumerable<AssignmentModel> Assignments { get; set; }

        public void PopulateData(int projectId) {
            using (PersonDao context = new PersonDao()) {
                Assignments = context.db.ProjectAssignments.Where(x => x.ProjectId == projectId).Select(x => new AssignmentModel() { Id=x.Id, ProjectId=projectId, PersonId=x.PersonId, PersonUsername=x.Person.Username }).ToList();
                AssignedPersons = context.GetPersonsAssignedToProject(projectId).Select(x => new PersonModel() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Username = x.Username }).ToList();
                AllPersons = context.GetAll<Person>().Select(x => new PersonModel() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Username = x.Username }).ToList();
            }
        }

    }
}