using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagmentApp.BLL;
using UniversityManagmentApp.DAL;

namespace UniversityManagmentApp.Controllers
{
    public class ScheduleController : Controller
    {
        private DepartmentManager aDepartmentManager = new DepartmentManager();

        private  ScheduleGateway aScheduleGateway= new ScheduleGateway();
        private  ScheduleManager aScheduleManager =new  ScheduleManager();
        //
        // GET: /Schedule/
        [HttpGet]
        public ActionResult ShowSchedule()
        {
            ViewBag.DepartmentBag = new SelectList(aDepartmentManager.GetAllDepartments().ToList(), "Id", "Name");
            return View();
        }


        public JsonResult ShowSchedule(int deptId)
        {
            var listOfCourse = aScheduleManager.GetAllCoursesSchedule();

            var ctList = listOfCourse.Where(a => a.DepartmentId== deptId).ToList();
            ViewBag.DepartmentBag = new SelectList(aDepartmentManager.GetAllDepartments().ToList(), "Id", "Name");
            return Json(ctList, JsonRequestBehavior.AllowGet);
        }

	}
}