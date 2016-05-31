using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Configuration;
using ControllerApp.Models;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.DAL
{
    public class DepartmentGateway:GateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public bool IsDeptExists(string code)
        
        {
            Query = "SELECT * FROM Departments WHERE Code='"+code+"'";

           
            Command.CommandText = Query;

            Connection.Open(); 
            Reader = Command.ExecuteReader();
            bool IsExists =  Reader.HasRows;
            Connection.Close();
            Reader.Close();
            return IsExists;
        }

        public int SaveDepartment(Department aDepartment)
        {
            Query = "INSERT INTO Departments VALUES('" + aDepartment.Code + "','" + aDepartment.Name + "')";
            Command.CommandText = Query;

            Connection.Open();
            int numOfRowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return numOfRowAffected;
      
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> allDepartments = new List<Department>();

            string query = "SELECT *FROM Departments";
            Command.CommandText = query;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = Convert.ToInt32(Reader["Id"]);
                aDepartment.Code = Reader["Code"].ToString();
                
                aDepartment.Name = Reader["Name"].ToString();
                allDepartments.Add(aDepartment);
            }

            Connection.Close();
            return allDepartments;

        }
    }
}