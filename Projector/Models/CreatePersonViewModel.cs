using Projector.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projector.Helpers;

namespace Projector.Models {
    public class CreatePersonViewModel {
        public PersonModel PersonModel { get; set; }

        internal void ValidateFields(PersonModel model, ModelStateDictionary modelState) {
            if (model.FirstName == "" || model.FirstName == null) {
                modelState.AddModelError("FNameRequired", "First Name is Required");
            }

            if (model.LastName == "" || model.LastName == null) {
                modelState.AddModelError("LNameRequired", "Last Name is Required");
            }

            if (model.Username == "" || model.Username == null) {
                modelState.AddModelError("UsernameRequired", "Username is Required");
            }

            if (model.Password == "" || model.Password == null) {
                modelState.AddModelError("PasswordRequired", "Password is Required");
            }

            if (model.FirstName == null || model.LastName == null || model.Password == null || model.Username == null) return;

            if (!(model.Username.Length >= 2 && model.Username.Length <= 200)) {
                modelState.AddModelError("UsernameLength", "Username must be more than 1 character and less than or equal to 200 characters");
            }

            if (!(model.FirstName.Length >= 2 && model.FirstName.Length <= 50)) {
                modelState.AddModelError("FnameLength", "First Name must be more than 1 character and less than or equal to 50 characters");
            }

            if (!(model.LastName.Length >= 2 && model.LastName.Length <= 50)) {
                modelState.AddModelError("LnameLength", "Last Name must be more than 1 character and less than or equal to 50 characters");
            }

            if (!model.Username.IsEmail()) {
                modelState.AddModelError("EmailRequired", "Username must be in email form");
            }

            if (model.Password.Contains(' ')) {
                modelState.AddModelError("SpaceNotAllowed", "Password must not have spaces");
            }
        }

        internal void CreatePerson(PersonModel personModel) {
            using (BasicDao context = new BasicDao()) {
                Person newPerson = new Person();
                newPerson.Username = personModel.Username;
                newPerson.Password = personModel.Password;
                newPerson.FirstName = personModel.FirstName;
                newPerson.LastName = personModel.LastName;
                context.Insert(newPerson);
            }
        }
    }
}