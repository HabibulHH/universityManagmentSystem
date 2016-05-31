using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagmentApp.BLL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.Controllers
{
    public class TeacherController : Controller
    {

        DesignationManager aDesignationManager= new DesignationManager();
        DepartmentManager aDepartmentManager= new DepartmentManager();
        TeacherManager aTeacherManager=new TeacherManager();

       
        //
        // GET: /Teacher/
      
        [HttpGet]
        public ActionResult SaveTeacher()
        {
            ViewBag.DesignationBag = aDesignationManager.GetAllDesignation();
            ViewBag.DepartmentBag = aDepartmentManager.GetAllDepartments();

            ViewBag.DepartmentBag = new SelectList(aDepartmentManager.GetAllDepartments().ToList(), "Id", "Name");
            ViewBag.DesignationBag = new SelectList(aDesignationManager.GetAllDesignation().ToList(), "Id", "DesignationName");
            
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {
            ViewBag.DesignationBag = aDesignationManager.GetAllDesignation();
            ViewBag.DepartmentBag = aDepartmentManager.GetAllDepartments();
            ViewBag.msg = aTeacherManager.SaveTeacher(aTeacher);
            ViewBag.DepartmentBag = new SelectList(aDepartmentManager.GetAllDepartments().ToList(), "Id", "Name");
            ViewBag.DesignationBag = new SelectList(aDesignationManager.GetAllDesignation().ToList(), "Id", "DesignationName");

            return View();
            
                
        }



        public ActionResult CourseAssignToTeacher()
        {
            TeacherManager oTeacherManager = new TeacherManager();
            ViewBag.Departments = oTeacherManager.GetAllDepartment();
            return View();
        }

        [HttpPost]
        public ActionResult CourseAssignToTeacher(int departmentId, int teacherId)
        {
            TeacherManager oTeacherManager = new TeacherManager();
            ViewBag.Departments = oTeacherManager.GetAllDepartment();
            return View();
        }

        [HttpPost]
        public JsonResult Save(int departmentId, int courseId, int teacherId)
        {

            TeacherManager oTeacherManager = new TeacherManager();
            string message = oTeacherManager.Save(departmentId, courseId, teacherId);
            return Json(message, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetTeacherByDepartmentId(int deptId)
        {

            TeacherManager oTeacherManager = new TeacherManager();
            List<Teacher> teacherList = oTeacherManager.GetAllTeacherByDepartmentId(deptId);

            return Json(teacherList, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetCourseByDepartmentId(int deptId)
        {

            TeacherManager oTeacherManager = new TeacherManager();
            List<Courses> courseList = oTeacherManager.GetAllCourseByDepartmentId(deptId);

            return Json(courseList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetCourseByDepartmentIdTeacherId(int deptId, int teacherId)
        {

            TeacherManager oTeacherManager = new TeacherManager();
            List<Courses> courseList = oTeacherManager.GetCourseByDepartmentIdTeacherId(deptId, teacherId);

            return Json(courseList, JsonRequestBehavior.AllowGet);

        }



        public JsonResult GetTeacherCreditInfo(int teacherId)
        {

            string tId = Convert.ToString(teacherId);
            TeacherManager oTeacherManager = new TeacherManager();
            List<Teacher> teacherList = oTeacherManager.GetTeacherCreditInfo(tId);

            return Json(teacherList, JsonRequestBehavior.AllowGet);

        }



        public JsonResult GetAllCourseInfo(string courseId)
        {

            string cId = Convert.ToString(courseId);
            TeacherManager oTeacherManager = new TeacherManager();
            List<Courses> courseList = oTeacherManager.GetAllCourseInfo(cId);

            return Json(courseList, JsonRequestBehavior.AllowGet);

        }

	}
}