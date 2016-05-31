using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagmentApp.BLL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.Controllers
{
    public class StudentResultController:Controller
    {
        //-----Suvro----

        public ActionResult StudentResult()
        {
            StudentResultManager oStudentResultManager = new StudentResultManager();            
            ViewBag.Students = oStudentResultManager.GetAllStudent();
            return View();
        }

        [HttpPost]
        public ActionResult StudentResult(int stuId, int courseId, string grade)
        {
            StudentResultManager oStudentResultManager = new StudentResultManager();
            ViewBag.Students = oStudentResultManager.GetAllStudent();
            return View();
        }



        [HttpPost]
        public JsonResult Save(int stuId, int courseId, string grade)
        {          

            StudentResultManager oStudentResultManager = new StudentResultManager();
            string message = oStudentResultManager.Save(stuId, courseId, grade);
            return Json(message, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetAllStudentByStudentId(int stuId)
        {
            string sId = Convert.ToString(stuId);
            StudentResultManager oStudentResultManager = new StudentResultManager();
            List<Student> studentList = oStudentResultManager.GetAllStudentByStudentId(sId);

            return Json(studentList, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetCourseByDepartmentIdStudentId(string deptId, int stuId)
        {
            string dId = Convert.ToString(deptId);
            string sId = Convert.ToString(stuId);

            StudentResultManager oStudentResultManager = new StudentResultManager();
            List<Courses> courseList = oStudentResultManager.GetAllCourseByDepartmentIdStudentRegNo(dId, sId);

            return Json(courseList, JsonRequestBehavior.AllowGet);

        }

    }
}