using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projector.Helpers;
using Projector.Data;
using System.Web.Security;

namespace Projector.Models {
    public class SignInModel {
        public string Username { get; set; }
        public string Password { get; set; }

        internal void ValidateFields(SignInModel model, ModelStateDictionary modelState) {
            if (model.Password == "" || model.Password == null) {
                modelState.AddModelError("PasswordRequired", "Password is Required");
            }

            if (model.Username == "" || model.Username == null) {
                modelState.AddModelError("UsernameRequired", "Username is Required");
            }

            if (!model.Username.IsEmail()) {
                modelState.AddModelError("EmailRequired", "Username must be in email form");
            }
        }

        internal void AuthenticateUser(HttpSessionStateBase Session,  ModelStateDictionary modelState) {
            using (PersonDao context = new PersonDao()) {
                if (!context.IsUserExisting(this.Username, this.Password)) {
                    modelState.AddModelError("UserNotExisting", "User does not exist");
                    return;
                }

                Person personEntity = context.GetUserFromAuth(this.Username, this.Password);
                Session["UserId"] = personEntity.Id;
                FormsAuthentication.SetAuthCookie(personEntity.Username, true);
            }
        }
    }
}