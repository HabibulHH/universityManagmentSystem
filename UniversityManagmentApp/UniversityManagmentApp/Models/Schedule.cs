using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagmentApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int RoomId  { get; set; }
        public string CourseCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RoomNo { get; set; }

        public string info { get; set; }


    }
}