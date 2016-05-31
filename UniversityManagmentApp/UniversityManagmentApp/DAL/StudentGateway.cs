using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using ControllerApp.Models;
using UniversityManagmentApp.Models;
using System.Data.SqlClient;

namespace UniversityManagmentApp.DAL
{
    public class StudentGateway:GateWay
    {

        public bool IsEmailExists(string email)
        {
            Query = "SELECT * FROM Students WHERE Email=@email";
            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = email;

            Command.CommandText = Query;

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExists = Reader.HasRows;
            Connection.Close();
            Reader.Close();
            return IsExists;
        }

        public int SaveStudent(Student aStudent)
        {
            Query = "INSERT INTO Students VALUES(@name,@email,@contactNo,@date,@address,@department,@regNo)";
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aStudent.Name;
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = aStudent.Email;
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aStudent.ContactNo;
            Command.Parameters.Add("date", SqlDbType.DateTime);
            Command.Parameters["date"].Value = aStudent.Date;
            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = aStudent.Address;
            Command.Parameters.Add("department", SqlDbType.VarChar);
            Command.Parameters["department"].Value = aStudent.Department;
            Command.Parameters.Add("regNo", SqlDbType.VarChar);
            Command.Parameters["regNo"].Value = aStudent.RegNo;

            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            return rowAffected;
        }
        public int CheckRegYear(string year)
        {
            Query = "SELECT year(Date) Yr FROM Students";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            int countYear = 0;
            while (Reader.Read())
            {
                if (Reader["Yr"].ToString() == year)
                {
                    countYear += 1;
                }
            }
            Reader.Close();
            Connection.Close();
            return countYear;
        }

        public int CheckDepartment(string departmentCode)
        {
            Query = "SELECT Department FROM Students";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            int countDept = 0;
            while (Reader.Read())
            {
                if (Reader["Department"].ToString() == departmentCode)
                {
                    countDept += 1;
                }
            }
            Reader.Close();
            Connection.Close();
            return countDept;
        }

        public List<Student> GetStudentByRegNo(int id)
        {
            Query = "SELECT * FROM Students WHERE Id=" + id;
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            List<Student> student = new List<Student>();
            while (Reader.Read())
            {
                Student aStudent = new Student();
                aStudent.RegNo = Reader["RegNo"].ToString();
                aStudent.Name = Reader["Name"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.Department = Reader["Department"].ToString();
                student.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return student;
        }

        public List<StudentResult> GetResultById(int studentId)
        {
            Query = "select c.Code,c.Name,sr.Grade from Courses c inner join EnrollInACourse ei on ei.CourseId= c.Id left outer join StudentResult sr on sr.CourseId=ei.CourseId where ei.StudentId=" + studentId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentResult> resultList = new List<StudentResult>();
            while (Reader.Read())
            {
                StudentResult result = new StudentResult();
                result.CourseCode = Reader["Code"].ToString();
                result.CourseName = Reader["Name"].ToString();
                if (Reader["Grade"].ToString() == null || Reader["Grade"].ToString() == "")
                {
                    result.Grade = "Not Graded Yet";
                }
                else
                {
                    result.Grade = Reader["Grade"].ToString();
                }
                resultList.Add(result);
            }
            Connection.Close();
            return resultList;
        }

        //----Student----

        public List<Student> GetAllStudent()
        {
            Query = "Select Id, RegNo from Students";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();


            List<Student> student = new List<Student>();

            while (Reader.Read())
            {
                Student oStudent = new Student();

                oStudent.Id = Convert.ToInt32(Reader["Id"]);
                oStudent.RegNo = (Reader["RegNo"]).ToString();

                student.Add(oStudent);
            }

            Connection.Close();
            return student;
        }


        public List<Student> GetAllStudentByStudentId(string studentId)
        {

            Query = "select s.Id, s.Name, s.Email, s.Department, d.Name as DepartmentName from Students s inner join Departments d on d.Code=s.Department where s.Id='" + studentId + "'";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();


            List<Student> student = new List<Student>();

            while (Reader.Read())
            {
                Student oStudent = new Student();

                oStudent.Id = Convert.ToInt32(Reader["Id"]);
                oStudent.Name = Reader["Name"].ToString();
                oStudent.Email = Reader["Email"].ToString();
                oStudent.Department = Reader["Department"].ToString();
                oStudent.DepartmentName = Reader["DepartmentName"].ToString();
                student.Add(oStudent);
            }

            Connection.Close();
            return student;
        }

        public List<Courses> GetAllCourseByDepartmentIdStudentRegNo(string departmentId, string studentId)
        {
            Query = "select c.Id, c.Name from Courses c inner join Departments d on d.Id=c.DepartmentId where c.Id not in ( select CourseId from EnrollInACourse where EnrollInACourse=1 and StudentId='" + studentId + "') and d.Code='" + departmentId + "'";

            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();


            List<Courses> courseses = new List<Courses>();

            while (Reader.Read())
            {
                Courses oCourses = new Courses();

                oCourses.Id = Convert.ToInt32(Reader["Id"]);
                oCourses.Name = Reader["Name"].ToString();
                courseses.Add(oCourses);
            }

            Connection.Close();
            return courseses;
        }

        public int Save(int studentId, int courseId, DateTime date)
        {
            Query = "INSERT INTO EnrollInACourse VALUES('" + studentId + "', '" + courseId + "', '" + date + "', '" + 1 + "')";

            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

    }
}