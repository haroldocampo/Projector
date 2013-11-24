using Projector.Data;
using Projector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projector.Controllers
{
    public class AssignmentController : ApiController
    {
        // GET api/assignment
        public IEnumerable<AssignmentModel> Get()
        {
            using (BasicDao context = new BasicDao()) {
                var allAssignments = context.GetAll<ProjectAssignment>().Select(x => new AssignmentModel() { Id = x.Id, PersonId = x.PersonId, PersonUsername = x.Person.Username, ProjectId = x.ProjectId }).ToList();
                return allAssignments;
            }
        }

        // GET api/assignment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/assignment
        public ProjectAssignment Post(AssignmentModel model) {
            using (BasicDao context = new BasicDao()) {
                ProjectAssignment newAssignment = new ProjectAssignment();
                newAssignment.PersonId = model.PersonId;
                newAssignment.ProjectId = model.ProjectId;
                context.Insert(newAssignment);
                return newAssignment;
            }
        }

        // PUT api/assignment/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/assignment/5
        public void Delete(int id) {
            using (BasicDao context = new BasicDao()) {
                context.Delete<ProjectAssignment>(id);
            }
        }
    }
}
