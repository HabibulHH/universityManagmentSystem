using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;

namespace UniversityManagmentApp.BLL
{
    public class UnAllocateAllClassroomManager
    {

        public string UpdateAllocateClassRoom()
        {
            string message = "";

            UnAllocateAllClassroomGateWay oUnAllocateAllClassroomGateWay = new UnAllocateAllClassroomGateWay();
            int a = oUnAllocateAllClassroomGateWay.UpdateAllocateClassRoom();

            if (a > 0 )
            {
                message = "UnAssign All Classroom Successfully";
            }

            return message;
        }

    }
}