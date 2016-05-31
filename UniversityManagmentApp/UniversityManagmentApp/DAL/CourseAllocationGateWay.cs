using System;
using System.Collections.Generic;
using ControllerApp.Models;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.DAL
{
    public class CourseAllocationGateWay : GateWay
    {
        public int AllocateCourse(RoomClassAllocation aRoomClassObject)
        {


            Query = "INSERT INTO AllocateClassRoom VALUES('" + aRoomClassObject.DepartmentId + "',"+ aRoomClassObject.RoomId +",'" + aRoomClassObject.StarTime + "','" + aRoomClassObject.EndTime + "'," + 1 +","+aRoomClassObject.CourseId+ ")";
            Command.CommandText = Query;

            Connection.Open();
            int numOfRowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return numOfRowAffected;

        }

        public IEnumerable<RoomClassAllocation> GetAllAllocatedRoom()
        {

            List<RoomClassAllocation> roomList = new List<RoomClassAllocation>();
            string query = "SELECT *FROM AllocateClassRoom";
            Command.CommandText = query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                RoomClassAllocation aRoomClassAllocation = new RoomClassAllocation();
                aRoomClassAllocation.DepartmentId = Convert.ToInt16(Reader["DepartmentId"]); 
                aRoomClassAllocation.RoomAllocationFlag = Convert.ToInt32(Reader["RoomFlag"]);
                aRoomClassAllocation.RoomId = Convert.ToInt16(Reader["RoomNo"]); 
                aRoomClassAllocation.StarTime = Convert.ToDateTime(Reader["StratDate"]);
                aRoomClassAllocation.EndTime = Convert.ToDateTime(Reader["EndDate"]);

                
                roomList.Add(aRoomClassAllocation);
            }

            Connection.Close();
            return roomList;



        }


    }
}