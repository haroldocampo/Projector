using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Projector.Helpers {
    public static class StringHelper {
        private static Regex CreateValidEmailRegex() {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        public static bool IsEmail(this string emailAddress) {
            if (emailAddress == null) {
                return false;
            }

            bool isValid = CreateValidEmailRegex().IsMatch(emailAddress);

            return isValid;
        }
    }
}