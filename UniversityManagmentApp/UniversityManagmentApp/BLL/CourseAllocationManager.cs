using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DateTimeValidator;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    public class CourseAllocationManager
    {
        CourseAllocationGateWay allocationGateWay= new CourseAllocationGateWay();
        private string message = "";
        public string AllocateCourse( RoomClassAllocation aRoomClassAllocation)
        {

            if (!checkOverLapping(aRoomClassAllocation))
            {
                if (allocationGateWay.AllocateCourse(aRoomClassAllocation) > 0)
                {
                    message = "Room Allocated";
                }
                else
                {
                    message = "Can not insert";
                }

            }

            else
            {
                message = "Time clashed";
            }
            return message;
        }


        public bool checkOverLapping(RoomClassAllocation aRoomClassAllocation)
        {

            IEnumerable<RoomClassAllocation> ListOfRooms = allocationGateWay.GetAllAllocatedRoom();

            RoomClassAllocation room= new RoomClassAllocation();
            foreach (var rooms in ListOfRooms)
            {
                if (rooms.RoomId.Equals(aRoomClassAllocation.RoomId))
                {
                    room = rooms;
                }
            }



            DateTime satarTime = room.StarTime;
            DateTime endTime = room.EndTime;
            DateTimeRange FixedRange = new DateTimeRange();
            FixedRange.Start = satarTime;
            FixedRange.End = endTime;
            DateTime testStarTime = aRoomClassAllocation.StarTime;
            DateTime testEndTime = aRoomClassAllocation.EndTime;

            DateTimeRange testThisTime = new DateTimeRange();
            testThisTime.Start = testStarTime;
            testThisTime.End = testEndTime;

            if (FixedRange.Intersects(testThisTime))
            {
                return true;
            }
            else
            {
                return false;
            }
            

           

        }


    }
}