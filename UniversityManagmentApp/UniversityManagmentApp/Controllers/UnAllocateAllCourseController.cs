using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagmentApp.BLL;

namespace UniversityManagmentApp.Controllers
{
    public class UnAllocateAllCourseController : Controller
    {
        //
        // GET: /UnAllocateAllCourse/
        public ActionResult UnAllocateAllCourse()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Update(int id)
        {
            UnAssignAllCourseManager oUnAssignAllCourseManager = new UnAssignAllCourseManager();
            string message = oUnAssignAllCourseManager.UnAssignAllCourse();
            return Json(message, JsonRequestBehavior.AllowGet);

        }
	}
}