using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControllerApp.Models;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.DAL
{
    public class ScheduleGateway: GateWay
    {


        public List<Schedule> GetAllSchedules()
        {

            List<Schedule> scheduleList = new List<Schedule>();
            string query = "SELECT *FROM Schedule";
            Command.CommandText = query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Schedule schedule = new Schedule();
                schedule.CourseCode = Reader["CODE"].ToString();
                schedule.Name = Reader["NAME"].ToString();
                schedule.RoomNo = Reader["RoomNo"].ToString();
                schedule.DepartmentId = Convert.ToInt16(Reader["DepartmentId"]);

                if (Reader.IsDBNull(4))
                {
                    schedule.info = "Not Allocate Yet ";
                }

                else
                {
                    schedule.StartTime = Convert.ToDateTime(Reader["STARTDATE"]);
                    schedule.EndTime = Convert.ToDateTime(Reader["ENDDATE"]);

                    string formate = "R. NO: " + schedule.RoomNo + ", " +
                                     schedule.StartTime.DayOfWeek.ToString().Substring(0, 3) + " " +
                                     schedule.StartTime.ToString("h:mm tt") + " -- " +
                                     schedule.EndTime.DayOfWeek.ToString().Substring(0, 3) + " " +
                                     schedule.EndTime.ToString("h:mm tt");

                    schedule.info = formate;
                    
                }
                

                scheduleList.Add(schedule);
            }

            Connection.Close();
            return scheduleList;

        }

    }
}