using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Web.Helpers;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.tool.xml.html.table;
using UniversityManagmentApp.BLL;
using UniversityManagmentApp.Models;


namespace UniversityManagmentApp.Controllers
{
    public class WebgridController : Controller
    {
        // GET: Webgrid
        public FileStreamResult GetPdf(int regNo)
        {
            StudentManager studentManager = new StudentManager();
            DepartmentManager aDepartmentManager = new DepartmentManager();
            IEnumerable<StudentResult> resultList = studentManager.GetResultById(regNo);
            List<Student> studentByRegNo = studentManager.GetStudentByRegNo(regNo);
            Student aStudent = new Student();
            foreach (Student student in studentByRegNo)
            {
                aStudent.RegNo = student.RegNo;
                aStudent.Name = student.Name;
                aStudent.Email = student.Email;
                aStudent.Department = student.Department;
            }
            WebGrid grid = new WebGrid(source: resultList, canPage: false, canSort: false);
            string gridHtml = grid.GetHtml(
                    columns: grid.Columns(
                            grid.Column("CourseCode", "Course Code"),
                grid.Column("CourseName", "Course Name"),
                grid.Column("Grade", "Grade")
                        )
                    ).ToString();
            var studentTable = MvcHtmlString.Create("<table><tr><td>Registration No:</td><td>" + aStudent.RegNo + "</td></tr><tr><td>Name:</td><td>" + aStudent.Name + "</td></tr><tr><td>Email:</td><td>" + aStudent.Email + "</td></tr><tr><td>Department:</td><td>" + aStudent.Department + "</td></tr></table>");
            string exportData1 = String.Format("<html><head>{0}</head><body>{1}</body></html>", "<style>table{ border-spacing: 10px; border-collapse: separate;font-family: verdana,arial,sans-serif;color:#333333; border-width: 1px; }</style>", studentTable);
            string exportData = String.Format("<html><head>{0}</head><body>{1}</body></html>", "<style>table{ border-spacing: 10px; border-collapse: separate;font-family: verdana,arial,sans-serif;color:#333333; border-width: 1px; border-color: #666666; }th{border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;color:darkgreen;}</style>", gridHtml);
            string exportDataFinal = exportData1 + exportData;
            var bytes = System.Text.Encoding.UTF8.GetBytes(exportDataFinal);
            using (var input = new MemoryStream(bytes))
            {
                var output = new MemoryStream();
                var document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 50, 50);
                var writer = PdfWriter.GetInstance(document, output);
                writer.CloseStream = false;
                document.Open();

                var xmlWorker = iTextSharp.tool.xml.XMLWorkerHelper.GetInstance();
                xmlWorker.ParseXHtml(writer, document, input, System.Text.Encoding.UTF8);
                document.Close();
                output.Position = 0;
                return new FileStreamResult(output, "application/pdf");
            }

        }
    }
}