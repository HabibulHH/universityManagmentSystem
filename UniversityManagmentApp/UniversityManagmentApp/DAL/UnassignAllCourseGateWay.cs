using ControllerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagmentApp.DAL
{
    public class UnAssignAllCourseGateWay:GateWay
    {


        public int UpdateCourseAssign()
        {
            Query = "update CourseAssignToTeacher set CourseAssign=0";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

        public int UpdateEnroll()
        {
            Query = "update EnrollInACourse set EnrollInACourse=0";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }


        public int UpdateStudentResult()
        {
            Query = "update StudentResult set StudentResult=0";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }


    }
}