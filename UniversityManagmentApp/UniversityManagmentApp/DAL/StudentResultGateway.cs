using ControllerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.DAL
{
    public class StudentResultGateway : GateWay
    {
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

            Query = "select s.Id, s.Name, s.Email, d.Id as departmentId, d.Name as DepartmentName from Students s inner join Departments d on d.Code=s.Department where s.Id='" + studentId + "'";
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
                oStudent.Department = Reader["departmentId"].ToString();
                oStudent.DepartmentName = Reader["DepartmentName"].ToString();
                student.Add(oStudent);
            }

            Connection.Close();
            return student;
        }

        public List<Courses> GetAllCourseByDepartmentIdStudentRegNo(string departmentId, string studentId)
        {
            Query = "select c.Id, c.Name from Courses c inner join Departments d on d.Id=c.DepartmentId where c.Id in ( select CourseId from EnrollInACourse where EnrollInACourse=1 and StudentId='" + studentId + "') and c.Id not in ( select CourseId from StudentResult where StudentResult=1 and StudentId='" + studentId + "')  and d.Id='" + departmentId + "'";

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

        public int Save(int studentId, int courseId, string grade)
        {
            Query = "INSERT INTO StudentResult VALUES('" + studentId + "', '" + courseId + "', '" + grade + "', '" + 1 + "')";

            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

    }
}