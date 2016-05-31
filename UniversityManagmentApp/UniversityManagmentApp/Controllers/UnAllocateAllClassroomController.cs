using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagmentApp.BLL;

namespace UniversityManagmentApp.Controllers
{
    public class UnAllocateAllClassroomController : Controller
    {
        //
        // GET: /UnAllocateAllClassroom/
        public ActionResult UnAllocateAllClassroom()
        {
            return View();
        }

        


        [HttpPost]
        public JsonResult Update(int id)
        {
            UnAllocateAllClassroomManager oUnAssignAllClassroomManager = new UnAllocateAllClassroomManager();
            string message=oUnAssignAllClassroomManager.UpdateAllocateClassRoom();
            return Json(message, JsonRequestBehavior.AllowGet);

        }


	}
}