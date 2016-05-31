using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagmentApp.Models
{
    public class Department
    {
        [Required(ErrorMessage ="Enter a  a valid code")]
        [StringLength(7,MinimumLength = 2)]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
    }
}