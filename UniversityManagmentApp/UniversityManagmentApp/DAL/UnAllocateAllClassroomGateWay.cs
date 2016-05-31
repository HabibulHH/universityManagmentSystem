using ControllerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagmentApp.DAL
{
    public class UnAllocateAllClassroomGateWay:GateWay
    {
        public int UpdateAllocateClassRoom()
        {
            Query = "update AllocateClassRoom set RoomFlag=0";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

    }
}