using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagmentApp.BLL;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.Controllers
{
    public class StudentController : Controller
    {

        DepartmentManager deptManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();
        //
        // GET: /Student/
        [HttpGet]
        public ActionResult RegisterStudent()
        {
            ViewBag.departmentBag = deptManager.GetAllDepartments();
            ViewBag.departmentBag = new SelectList(deptManager.GetAllDepartments(), "Code", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student aStudent)
        {
            ViewBag.departmentBag = deptManager.GetAllDepartments();
            ViewBag.departmentBag = new SelectList(deptManager.GetAllDepartments(), "Code", "Name");
            ViewBag.savedMessage = studentManager.SaveStudent(aStudent);

            return View();
        }


        //-----Suvro----

        public ActionResult StudentEnrollInACourse()
        {
            StudentManager oStudentManager = new StudentManager();
            ViewBag.Students = oStudentManager.GetAllStudent();
            return View();
        }

        [HttpPost]
        public ActionResult StudentEnrollInACourse(int studentRegNo, int courseId, string date)
        {

            StudentManager oStudentManager = new StudentManager();
            ViewBag.Students = oStudentManager.GetAllStudent();
            return View();
        }


        public JsonResult Save(int stuId, int courseId, DateTime date)
        {
            DateTime Date = Convert.ToDateTime(date);

            StudentManager oStudentManager = new StudentManager();
            string message = oStudentManager.Save(stuId, courseId, Date);
            return Json(message, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetAllStudentByStudentId(int stuId)
        {
            string sId = Convert.ToString(stuId);
            StudentManager oStudentManager = new StudentManager();
            List<Student> studentList = oStudentManager.GetAllStudentByStudentId(sId);

            return Json(studentList, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetCourseByDepartmentIdStudentId(string deptId, int stuId)
        {
            string dId = Convert.ToString(deptId);
            string sId = Convert.ToString(stuId);

            StudentManager oStudentManager = new StudentManager();
            List<Courses> courseList = oStudentManager.GetAllCourseByDepartmentIdStudentRegNo(dId, sId);

            return Json(courseList, JsonRequestBehavior.AllowGet);

        }










	}
}