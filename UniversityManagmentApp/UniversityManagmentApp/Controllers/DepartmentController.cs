using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagmentApp.BLL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.Controllers
{
    public class DepartmentController : Controller
    {

        DepartmentManager aDepartmentManager= new DepartmentManager();
        //
        // GET: /Department/
        
        [HttpGet]
        public ActionResult DepartmentSave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmentSave( Department aDepartment)
        {

          ViewBag.successMessage=aDepartmentManager.SaveDepartment(aDepartment);
            return View();


        }
        [HttpGet]
        public ActionResult ShowDepartment()
        {
            IEnumerable<Department> dptList = aDepartmentManager.GetAllDepartments();
            return View(dptList);
        }


        [HttpPost]
        public ActionResult ShowDepartment(Department aDepartment)
        {
            IEnumerable<Department> dptList = aDepartmentManager.GetAllDepartments();
            return View(dptList);
        }
    }
}