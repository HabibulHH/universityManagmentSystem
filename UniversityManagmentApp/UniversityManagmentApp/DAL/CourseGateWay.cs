using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ControllerApp.Models;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.DAL
{
    public class CourseGateWay : GateWay
    {


        public List<ViewCourse> ViewCourse(int depertmentId)
        {

            List<ViewCourse> courseList = new List<ViewCourse>();
            string query = "SELECT *FROM CourseView WHERE DepartmentId=" + depertmentId;
            Command.CommandText = query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewCourse aCourse = new ViewCourse();
                aCourse.Code = Reader["Code"].ToString();
                aCourse.Name = Reader["Name"].ToString();
                aCourse.Semester = Reader["SEMESTER"].ToString();
                aCourse.AssignedTo = Reader.IsDBNull(4) ? "Not assigned" : Reader["TeachersName"].ToString();

                aCourse.Department = Convert.ToInt32(Reader["DepartmentId"]);
                courseList.Add(aCourse);
            }

            Connection.Close();
            return courseList;

        }

        public bool IsCourseCodeExists(string code)
        {
            Query = "SELECT * FROM Courses WHERE Code=@code";
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = code;

            Command.CommandText = Query;

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExists = Reader.HasRows;
            Connection.Close();
            Reader.Close();
            return IsExists;
        }
        public bool IsCourseNameExists(string name)
        {
            Query = "SELECT * FROM Courses WHERE Name=@name";
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = name;

            Command.CommandText = Query;

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExists = Reader.HasRows;
            Connection.Close();
            Reader.Close();
            return IsExists;
        }

        public int SaveCourse(Courses aCourse)
        {
            Query = "INSERT INTO Courses VALUES(@name,@code,@credit,@description,@department,@semester)";
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aCourse.Name;
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = aCourse.Code;
            Command.Parameters.Add("credit", SqlDbType.Decimal);
            Command.Parameters["credit"].Value = aCourse.Credit;
            Command.Parameters.Add("description", SqlDbType.VarChar);
            Command.Parameters["description"].Value = aCourse.Description;
            Command.Parameters.Add("department", SqlDbType.VarChar);
            Command.Parameters["department"].Value = aCourse.DepartmentCode;
            Command.Parameters.Add("semester", SqlDbType.VarChar);
            Command.Parameters["semester"].Value = aCourse.SemesterId;

            Command.CommandText = Query;
            Connection.Open();
            int numOfRowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return numOfRowAffected;
        }


        public List<Courses> GetAllCourses()
        {
            List<Courses> courseList = new List<Courses>();
            Query = "SELECT * FROM Courses";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Courses aCourse = new Courses();
                aCourse.Code = Reader["Code"].ToString();
                aCourse.Name = Reader["Name"].ToString();
                //aCourse.DepartmentCode = Reader["Id"].ToString();
                aCourse.DepartmentId = Convert.ToInt16(Reader["DepartmentId"]);
                aCourse.Id = Convert.ToInt16(Reader["Id"]); 
                courseList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }


    }


}






