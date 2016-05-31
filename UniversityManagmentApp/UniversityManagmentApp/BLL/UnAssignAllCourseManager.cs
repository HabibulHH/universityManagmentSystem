using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;

namespace UniversityManagmentApp.BLL
{
    public class UnAssignAllCourseManager
    {
        public string UnAssignAllCourse()
        {
            string message="";

            UnAssignAllCourseGateWay oUnAssignAllCourseGateWay = new UnAssignAllCourseGateWay();

            int a = oUnAssignAllCourseGateWay.UpdateCourseAssign();
            int b = oUnAssignAllCourseGateWay.UpdateEnroll();
            int c = oUnAssignAllCourseGateWay.UpdateStudentResult();

            if (a>0 && b>0 && c>0)
            {
                message = "UnAssign All Course Successfully"; 
            }

            return message;

        }
    }
}