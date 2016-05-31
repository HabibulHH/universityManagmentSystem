using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    public class CourseManager
    {

        CourseGateWay courseGateway = new CourseGateWay();

        public string SaveCourse(Courses aCourse)
        {
            if (courseGateway.IsCourseCodeExists(aCourse.Code))
            {
                return "Course Code already exists!";
            }
            else
            {
                if (courseGateway.IsCourseNameExists(aCourse.Name))
                {
                    return "Course Name already exists!";
                }
                else
                {
                    int rowsAffected = courseGateway.SaveCourse(aCourse);
                    if (rowsAffected > 0)
                    {
                        return "Saved Successfully.";
                    }
                    else
                    {
                        return "Saving failed.";
                    }
                }
            }
        }

        public List<Courses> GetAllCourseses()
        {
            return courseGateway.GetAllCourses();
        }

    }
}