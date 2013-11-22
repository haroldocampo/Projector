using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projector.Models {
    public class ProjectModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Budget { get; set; }
        public string Remarks { get; set; }
    }
}