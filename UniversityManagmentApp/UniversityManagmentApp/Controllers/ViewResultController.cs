using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UniversityManagmentApp.BLL;
using UniversityManagmentApp.Models;



namespace UniversityManagmentApp.Controllers
{
    public class ViewResultController : Controller
    {
        DepartmentManager deptManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();
        // GET: ViewResult
        public ActionResult ViewResult()
        {
            ViewBag.studentbag = studentManager.GetAllStudent();
            IEnumerable<Department> deptList = deptManager.GetAllDepartments();
            return View(deptList);
        }


        public JsonResult GetStudentInfo(int id)
        {

            List<Student> studentByRegNo = studentManager.GetStudentByRegNo(id);

            return Json(studentByRegNo, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetResultByStudentId(int id)
        {

            List<StudentResult> oStudentResult = studentManager.GetResultById(id);

            return Json(oStudentResult, JsonRequestBehavior.AllowGet);

        }
    }
}
