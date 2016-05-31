using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControllerApp.Models;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.DAL
{
    public class RoomGateWay:GateWay
    {
        public IEnumerable<Room> GetAllRoom()
        {
            List<Room> allRoom = new List<Room>();

            string query = "SELECT *FROM Rooms";
            Command.CommandText = query;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Room aRoom = new Room();
                aRoom.Id = Convert.ToInt32(Reader["Id"]);


                aRoom.RoomNumber = Reader["RoomNo"].ToString();
                allRoom.Add(aRoom);
            }

            Connection.Close();
            return allRoom;

        }
 
    }
}