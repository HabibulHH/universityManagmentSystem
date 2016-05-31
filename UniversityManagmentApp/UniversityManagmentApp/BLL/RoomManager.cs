using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    public class RoomManager
    {
        RoomGateWay aRoomGateWay = new RoomGateWay();

        public IEnumerable<Room> GetRooms()
        {
            return aRoomGateWay.GetAllRoom();
        }

    }
}