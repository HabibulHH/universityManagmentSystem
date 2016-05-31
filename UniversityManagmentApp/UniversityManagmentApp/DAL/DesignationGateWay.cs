using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControllerApp.Models;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.DAL
{
    public class DesignationGateWay:GateWay
    {
        public IEnumerable<Designation> GetAllDesignation()
        {
            List<Designation> aDesignationList = new List<Designation>();

            string query = "SELECT *FROM Designation";
            Command.CommandText = query;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.Id = Convert.ToInt32(Reader["Id"]);


                aDesignation.DesignationName = Reader["Designation"].ToString();
                aDesignationList.Add(aDesignation);
            }

            Connection.Close();
            return aDesignationList;

        }
 
    }
}