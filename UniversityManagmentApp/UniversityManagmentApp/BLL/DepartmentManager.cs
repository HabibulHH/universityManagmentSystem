using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway dptGateway = new DepartmentGateway();
        public string SaveDepartment(Department aDepartment)
        {
            if (dptGateway.IsDeptExists(aDepartment.Code))
            {
                return "Department already exists!";
            }
            else
            {
                int rowsAffected = dptGateway.SaveDepartment(aDepartment);
                if (rowsAffected>0)
                {
                    return "Saved Successfully.";
                }
                else
                {
                    return "Saving failed.";
                }
            }
        }

        public IEnumerable<Department> GetAllDepartments()//2
        {
            return dptGateway.GetAllDepartments();
        }
    }
}