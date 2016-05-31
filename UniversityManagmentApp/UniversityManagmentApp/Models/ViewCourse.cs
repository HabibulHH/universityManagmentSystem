using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagmentApp.Models
{
    public class ViewCourse
    {
        public string   Code{ get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public int Department { get; set; }
        public  string AssignedTo { get; set; }
    }
}