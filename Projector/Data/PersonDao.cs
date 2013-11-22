using Projector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projector.Data {
    public class PersonDao : BasicDao {

        public Person GetUserFromAuth(string username, string password){
            return db.Persons.Where(x => x.Username == username && x.Password == password).Single();
        }

        public IEnumerable<Person> GetPersonsAssignedToProject(int projectId) {
            return db.ProjectAssignments.Where(x => x.ProjectId == projectId).Select(x => x.Person);
        }

        public bool IsUserExisting(string username, string password) {
            return db.Persons.Where(x => x.Username == username && x.Password == password).Any();
        }

    }
}