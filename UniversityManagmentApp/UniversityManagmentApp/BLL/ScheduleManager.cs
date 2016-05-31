using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagmentApp.DAL;
using UniversityManagmentApp.Models;

namespace UniversityManagmentApp.BLL
{
    public class ScheduleManager
    {

        ScheduleGateway aScheduleGateway = new ScheduleGateway();


        public List<Schedule> GetAllCoursesSchedule()
        {

            List<Schedule> allSchedule = aScheduleGateway.GetAllSchedules();
            List<Schedule> uniqueSchedule = new List<Schedule>();
            List<string> code = new List<string>();

            foreach (var aSchedule in allSchedule)
            {
                //list not contain the course code
                if (!code.Contains(aSchedule.CourseCode))
                {

                    var ctList = allSchedule.Where(a => a.CourseCode == aSchedule.CourseCode).ToList();

                    for (int i = 1; i < ctList.Count; i++)
                    {
                        aSchedule.info += "<br>" + ctList[i].info;
                    }
                    //foreach (var sc in ctList)
                    //{
                    //    aSchedule.info += " " + sc.info;
                    //}
                    code.Add(aSchedule.CourseCode);
                    uniqueSchedule.Add(aSchedule);

                }
            }
            return uniqueSchedule;
        }
    }
}