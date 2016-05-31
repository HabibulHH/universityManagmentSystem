using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    public class StudentResultManager
    {

        public List<Student> GetAllStudent()
        {
            StudentResultGateway oStudentResultGateway = new StudentResultGateway();
            return oStudentResultGateway.GetAllStudent();
        }


        public List<Student> GetAllStudentByStudentId(string studentId)
        {
            StudentResultGateway oStudentResultGateway = new StudentResultGateway();
            return oStudentResultGateway.GetAllStudentByStudentId(studentId);
        }

        public List<Courses> GetAllCourseByDepartmentIdStudentRegNo(string departmentId, string studentId)
        {
            StudentResultGateway oStudentResultGateway = new StudentResultGateway();
            return oStudentResultGateway.GetAllCourseByDepartmentIdStudentRegNo(departmentId, studentId);
        }

        public string Save(int stuId, int courseId, string grade)
        {

            StudentResultGateway oStudentResultGateway = new StudentResultGateway();
            int value = oStudentResultGateway.Save(stuId, courseId, grade);

            string message;

            if (value != null)
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