using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projector.Models {
    public class AssignmentModel {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
        public string PersonUsername { get; set; }
    }
}