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
    public class CourseController : Controller
    {
        private CourseGateWay acourseGetway = new CourseGateWay();
        private CourseGateWay acuCourseGateWay = new CourseGateWay();
        private DepartmentManager aDepartmentManager = new DepartmentManager();
        SemesterManager semManager = new SemesterManager();
        CourseManager aCourseManager =  new CourseManager();

        //
        // GET: /Course/
        [HttpGet]
        public ActionResult ViewCourseStatistics()
        {



            ViewBag.DepartmentBag = new SelectList(aDepartmentManager.GetAllDepartments().ToList(), "Id", "Name");

            return View();
        }

        public JsonResult ViewCourseStatistics(int deptId)
        {
            var listOfCourse = acourseGetway.ViewCourse(deptId);
            ViewBag.DepartmentBag = new SelectList(aDepartmentManager.GetAllDepartments().ToList(), "Id", "Name");
            return Json(listOfCourse, JsonRequestBehavior.AllowGet);
        }

      

        [HttpGet]
        public ActionResult SaveCourse()
        {
            ViewBag.departmentBag = aDepartmentManager.GetAllDepartments();
            ViewBag.semesterBag = semManager.GetAllSemesters();

            ViewBag.departmentBag = new SelectList(aDepartmentManager.GetAllDepartments().ToList(), "Id", "Name");
            ViewBag.semesterBag = new SelectList(semManager.GetAllSemesters().ToList(), "Id", "Semester");

            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(Courses aCourses)
        {
            ViewBag.departmentBag = aDepartmentManager.GetAllDepartments();
            ViewBag.semesterBag = semManager.GetAllSemesters();

            ViewBag.departmentBag = new SelectList(aDepartmentManager.GetAllDepartments().ToList(), "Id", "Name");
            ViewBag.semesterBag = new SelectList(semManager.GetAllSemesters().ToList(), "Id", "Semester");
            ViewBag.saveMessage = aCourseManager.SaveCourse(aCourses);
            return View();
        }

    
    }





}