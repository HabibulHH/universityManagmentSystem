using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();

        public string SaveStudent(Student aStudent)
        {
            if (studentGateway.IsEmailExists(aStudent.Email))
            {
                return "Email No already exists!";
            }
            else
            {
                aStudent.RegNo = GenerateRegNo(aStudent);

                int rowAffected = studentGateway.SaveStudent(aStudent);
                if (rowAffected > 0)
                {
                    //ViewStudent(aStudent);
                    return "Student has been saved successfully." + "\n" + " Student Name: " + aStudent.Name + "Student Email: " + aStudent.Email + "Contact No: " + aStudent.ContactNo + "Registration Date: " + aStudent.Date + "Address: " + aStudent.Address + "Department: " + aStudent.Department + "Registration No: " + aStudent.RegNo;
                }
                else
                {
                    return "Cannot be saved!";
                }
            }
        }

        public string GenerateRegNo(Student aStudent)
        {
            DateTime dtTime = Convert.ToDateTime(aStudent.Date);
            string year = dtTime.Year.ToString();
            int count = 1;
            string regNo = "";
            if (studentGateway.CheckDepartment(aStudent.Department) > 0)
            {
                if (studentGateway.CheckRegYear(year) > 0)
                {
                    count += studentGateway.CheckRegYear(year);
                }
                else
                {
                    count = 1;
                }
                string rr = count.ToString("000");
                regNo = aStudent.Department + "-" + year + "-" + rr;
            }
            else
            {
                int r = 1;
                string rr = r.ToString("000");
                regNo = aStudent.Department + "-" + year + "-" + rr;
            }
            return regNo;
        }

        public List<Student> GetStudentByRegNo(int studentId)
        {
            return studentGateway.GetStudentByRegNo(studentId);
        }

        public List<StudentResult> GetResultById(int studentId)
        {
            return studentGateway.GetResultById(studentId);
        }

        //-------Suvro----


        public List<Student> GetAllStudent()
        {

            StudentGateway oStudentGateway = new StudentGateway();
            return oStudentGateway.GetAllStudent();
        }


        public List<Student> GetAllStudentByStudentId(string studentId)
        {

            StudentGateway oStudentGateway = new StudentGateway();
            return oStudentGateway.GetAllStudentByStudentId(studentId);
        }

        public List<Courses> GetAllCourseByDepartmentIdStudentRegNo(string departmentId, string studentId)
        {
            StudentGateway oStudentGateway = new StudentGateway();
            return oStudentGateway.GetAllCourseByDepartmentIdStudentRegNo(departmentId, studentId);
        }

        public string Save(int studentRegNo, int courseId, DateTime date)
        {

            StudentGateway oStudentGateway = new StudentGateway();
            int value = oStudentGateway.Save(studentRegNo, courseId, date);

            string message;

            if (value>0)
            {
                message = "Save Successfully";
            }
            else
            {
                message = "Not Saved";
            }

            return message;
        }


    }
}