using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using UniversityManagmentApp.BLL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.Controllers
{
    public class AllocateClassRoomController : Controller
    {
        CourseAllocationManager aCourseAllocationManager= new CourseAllocationManager();
        DepartmentManager aDepartmentManager=new DepartmentManager();

        CourseManager aCourseManager= new CourseManager();

        RoomManager aRoomManager= new RoomManager();


        //
        // GET: /AllocateClassRoom/



        public JsonResult GetCouorseByDepartmentId(int DepartmentId)
        {
               var allCourseses = aCourseManager.GetAllCourseses();
               var ctList = allCourseses.Where(a => a.DepartmentId == DepartmentId).ToList();
               
                return Json(ctList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AllocateRoom()
        {


            ViewBag.DepartmentBag = aDepartmentManager.GetAllDepartments();//1
            ViewBag.RoomBag = aRoomManager.GetRooms();

            return View();
        }

        [HttpPost]
        public ActionResult AllocateRoom(RoomClassAllocation aRoomClass)
        {
            ViewBag.Message = aCourseAllocationManager.AllocateCourse(aRoomClass);
            ViewBag.DepartmentBag = aDepartmentManager.GetAllDepartments();
            ViewBag.RoomBag = aRoomManager.GetRooms();
            return View();
        }
	}
}