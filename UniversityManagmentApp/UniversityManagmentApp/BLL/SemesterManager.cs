using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    public class SemesterManager
    {
        SemesterGateway semGateway = new SemesterGateway();

        public IEnumerable<Semesters> GetAllSemesters()
        {
            return semGateway.GetAllSemesterses();
        }
    }
}