using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ControllerApp.Models;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.DAL
{
    public class SemesterGateway:GateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public IEnumerable<Semesters> GetAllSemesterses()
        {
            List<Semesters> semesterList = new List<Semesters>();
            Query = "SELECT * FROM Semesters";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Semesters semester = new Semesters();
                semester.Id = Convert.ToInt32(Reader["Id"]);
                semester.Semester = Reader["Name"].ToString();
                semesterList.Add(semester);
            }
            Reader.Close();
            Connection.Close();

            return semesterList;
        }
    }
}