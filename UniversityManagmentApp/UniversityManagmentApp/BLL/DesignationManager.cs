using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    public class DesignationManager
    {
        DesignationGateWay aDesignationGateWay= new DesignationGateWay();


        public IEnumerable<Designation> GetAllDesignation()
        {
            return aDesignationGateWay.GetAllDesignation();
        }

    }
}