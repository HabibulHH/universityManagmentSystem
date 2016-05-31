using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagmentApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public int DesignationId { get; set; }

        [Required]
        public string DepartmentCode { get; set; }

        [Required]

        public decimal RemainingCredit { get; set; }
        [Required]
        public decimal CreditToBeTaken { get; set; }

    }
}