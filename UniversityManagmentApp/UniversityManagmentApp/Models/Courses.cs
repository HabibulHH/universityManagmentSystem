using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace UniversityManagmentApp.Models
{
    public class Courses
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength = 5)]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.5,5.0)]
        public Decimal Credit { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DepartmentCode { get; set; }

        [Required] public int DepartmentId;
        public int SemesterId { get; set; }
    }
}