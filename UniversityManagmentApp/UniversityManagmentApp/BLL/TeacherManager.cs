using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    
    public class TeacherManager
    {

        TeacherGateWay aTeacherGateWay = new TeacherGateWay();

        public string SaveTeacher(Teacher aTeacher)
        {
            if (aTeacherGateWay.IsEmailExists(aTeacher))
            {
                if (aTeacherGateWay.SaveTeacher(aTeacher) > 0)
                    return "SAVED";
                else
                {
                    return "Not saved ..";
                }
            }
            else
            {
                return "Emial exists ";
            }


        }

        public List<Department> GetAllDepartment()
        {

            TeacherGateWay oTeacherGateWay = new TeacherGateWay();
            return oTeacherGateWay.GetAllDepartment();
        }
        public List<Teacher> GetAllTeacherByDepartmentId(int departmentId)
        {
            TeacherGateWay oTeacherGateWay = new TeacherGateWay();
            return oTeacherGateWay.GetAllTeacherByDepartmentId(departmentId);
        }

        public List<Courses> GetAllCourseByDepartmentId(int departmentId)
        {
            TeacherGateWay oTeacherGateWay = new TeacherGateWay();
            return oTeacherGateWay.GetAllCourseByDepartmentId(departmentId);
        }

        public List<Courses> GetCourseByDepartmentIdTeacherId(int departmentId, int teacherId)
        {
            TeacherGateWay oTeacherGateWay = new TeacherGateWay();
            return oTeacherGateWay.GetAllCourseByDepartmentIdTeacherId(departmentId, teacherId);
        }




        public List<Teacher> GetTeacherCreditInfo(string teacherId)
        {

            TeacherGateWay oTeacherGateWay = new TeacherGateWay();
            decimal CreditToBeTaken = oTeacherGateWay.GetTeacherCreditToBeTaken(teacherId);
            decimal CreditTaken = oTeacherGateWay.GetTeacherCreditTaken(teacherId);
            decimal RemainingCredit = CreditToBeTaken - CreditTaken;

            Teacher oTeacher = new Teacher();
            oTeacher.CreditToBeTaken = CreditToBeTaken;
            oTeacher.RemainingCredit = RemainingCredit;

            List<Teacher> teachers = new List<Teacher>();
            teachers.Add(oTeacher);
            return teachers;

        }


        public List<Courses> GetAllCourseInfo(string courseId)
        {
            TeacherGateWay oTeacherGateWay = new TeacherGateWay();
            return oTeacherGateWay.GetAllCourseInfo(courseId);
        }


        public string Save(int departmentId, int courseId, int teacherId)
        {
            TeacherGateWay oTeacherGateWay = new TeacherGateWay();
            int value = oTeacherGateWay.Save(departmentId, courseId, teacherId);

            string message;

            if (value > 0)
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