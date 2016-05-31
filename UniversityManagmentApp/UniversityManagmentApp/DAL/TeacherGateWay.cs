using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ControllerApp.Models;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.DAL
{
    public class TeacherGateWay:GateWay
    {

        public int SaveTeacher(Teacher aTeacher)
        {

            Query = "INSERT INTO Teachers VALUES(@Name,@Address,@Email,@ContactNo,@Designation,@Department,@CreditToBeTaken)";
            Command.Parameters.Clear();
            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = aTeacher.Name;
            Command.Parameters.Add("Address", SqlDbType.VarChar);
            Command.Parameters["Address"].Value = aTeacher.Address;
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = aTeacher.Email;
            Command.Parameters.Add("ContactNo", SqlDbType.VarChar);
            Command.Parameters["ContactNo"].Value = aTeacher.ContactNo;
            Command.Parameters.Add("Designation", SqlDbType.Int);
            Command.Parameters["Designation"].Value = aTeacher.DesignationId;
            Command.Parameters.Add("Department", SqlDbType.Int);
            Command.Parameters["Department"].Value = aTeacher.DepartmentCode;// dept code is int fk

            Command.Parameters.Add("CreditToBeTaken", SqlDbType.Int);
            Command.Parameters["CreditToBeTaken"].Value = aTeacher.CreditToBeTaken;

            Command.CommandText = Query;
            Connection.Open();
            int numOfRowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return numOfRowAffected;

        }



        public bool IsEmailExists(Teacher aTeacher)
        {


            string query = "SELECT *FROM Teachers WHERE Email=" + "'" + aTeacher.Email + "'";
            Command.CommandText = query;
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows != true)
            {

                Connection.Close();
                return true; // email does not exists
            }

            else
            {
                Connection.Close();
                return false;
            }


        }

        //------------suvro---------





        public List<Department> GetAllDepartment()
        {
            Query = "Select * from Departments";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();


            List<Department> department = new List<Department>();

            while (Reader.Read())
            {
                Department oDepartment = new Department();

                oDepartment.Id = Convert.ToInt32(Reader["Id"]);
                oDepartment.Code = (Reader["Code"]).ToString();
                oDepartment.Name = Reader["Name"].ToString();
                department.Add(oDepartment);
            }

            Connection.Close();
            return department;
        }






        public List<Teacher> GetAllTeacherByDepartmentId(int departmentId)
        {
            Query = "select * from Teachers where Department=" + departmentId;
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();


            List<Teacher> teachers = new List<Teacher>();

            while (Reader.Read())
            {
                Teacher oTeacher = new Teacher();

                oTeacher.Id = Convert.ToInt32(Reader["Id"]);
                oTeacher.Name = Reader["Name"].ToString();
                teachers.Add(oTeacher);
            }

            Connection.Close();
            return teachers;
        }

        public List<Courses> GetAllCourseByDepartmentId(int departmentId)
        {
            Query = "select * from Courses where DepartmentId=" + departmentId;
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();


            List<Courses> courseses = new List<Courses>();

            while (Reader.Read())
            {
                Courses oCourses = new Courses();

                oCourses.Id = Convert.ToInt32(Reader["Id"]);
                oCourses.Code = Reader["Code"].ToString();
                courseses.Add(oCourses);
            }

            Connection.Close();
            return courseses;
        }

        public List<Courses> GetAllCourseByDepartmentIdTeacherId(int departmentId, int teacherId)
        {
            Query = "select c.Id, c.Code from Courses c inner join Departments d on d.Id=c.DepartmentId where c.Id not in (select CourseId from CourseAssignToTeacher where TeacherID=" + teacherId + ") and d.Id=" + departmentId;
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();


            List<Courses> courseses = new List<Courses>();

            while (Reader.Read())
            {
                Courses oCourses = new Courses();

                oCourses.Id = Convert.ToInt32(Reader["Id"]);
                oCourses.Code = Reader["Code"].ToString();
                courseses.Add(oCourses);
            }

            Connection.Close();
            return courseses;
        }




        public decimal GetTeacherCreditToBeTaken(string teacherId)
        {

            Query = "select * from Teachers where Id='" + teacherId + "'";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();


            //List<Teacher> teachers = new List<Teacher>();
            decimal CreditToBeTaken = 0;

            while (Reader.Read())
            {

                if (Reader["CreditToBeTaken"] != DBNull.Value)
                    CreditToBeTaken = Convert.ToDecimal(Reader["CreditToBeTaken"]);




            }
            Connection.Close();
            return CreditToBeTaken;

        }



        public decimal GetTeacherCreditTaken(string teacherId)
        {

            Query = "select isnull (sum(c.Credit), 0) CreditTaken from CourseAssignToTeacher cat inner join Departments d on d.Id=cat.DepartmentId inner join Courses c on c.Id=cat.CourseId inner join Teachers t on t.Id=cat.TeacherId where t.Id='" + teacherId + "'";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();

            //List<Teacher> teachers = new List<Teacher>();

            decimal CreditTaken = 0;

            while (Reader.Read())
            {
                //Teacher oTeacher = new Teacher();
                CreditTaken = Convert.ToDecimal(Reader["CreditTaken"]);
                //teachers.Add(oTeacher);

            }
            Connection.Close();
            return CreditTaken;

        }


        public List<Courses> GetAllCourseInfo(string courseId)
        {
            Query = "select * from Courses where Id='" + courseId + "'";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();


            List<Courses> courseses = new List<Courses>();

            while (Reader.Read())
            {
                Courses oCourses = new Courses();

                oCourses.Id = Convert.ToInt32(Reader["Id"]);
                oCourses.Code = Reader["Code"].ToString();
                oCourses.Name = Reader["Name"].ToString();
                oCourses.Credit = Convert.ToDecimal(Reader["Credit"].ToString());
                courseses.Add(oCourses);
            }

            Connection.Close();
            return courseses;
        }

        public int Save(int departmentId, int courseId, int teacherId)
        {
            Query = "INSERT INTO CourseAssignToTeacher VALUES(" + departmentId + "," + teacherId + "," + courseId + "," + 1 + ")";

            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

    }
}