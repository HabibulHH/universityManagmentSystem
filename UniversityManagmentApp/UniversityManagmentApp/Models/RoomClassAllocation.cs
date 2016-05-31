using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagmentApp.Models
{
    public class RoomClassAllocation
    {
        public int DepartmentId { get; set; }
        public  int CourseId { get; set; }

        public int RoomId { get; set; }

        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }

        public int RoomAllocationFlag { get; set; }

    }
}