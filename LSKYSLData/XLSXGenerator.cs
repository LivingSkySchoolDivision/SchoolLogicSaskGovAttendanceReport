using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace LSKYSLData
{
    public static class XLSXGenerator
    {
        private const string WorksheetName = "Records";
        private const string WorksheetFont = "Calibri";
        private const int WorksheetFontSize = 10;

        /// <summary>
        /// Generate an XLSX document for DAILY attendance students
        /// </summary>
        /// <param name="studentsBySchool">List of students</param>
        /// <param name="startTime">Start of the date range used for the report</param>
        /// <param name="endTime">End of the date range used for the report</param>
        /// <param name="divisionDAN">The division's government ID number</param>
        /// <returns></returns>
        public static MemoryStream GenerateXLSX_Daily(Dictionary<School, List<Student>> studentsBySchool, DateTime startTime,
           DateTime endTime, string divisionDAN)
        {
            MemoryStream returnMe = new MemoryStream();
            using (ExcelPackage xlPackage = new ExcelPackage(returnMe))
            {
                xlPackage.Workbook.Worksheets.Add(WorksheetName);
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[WorksheetName];
                worksheet.Cells.Style.Font.Size = WorksheetFontSize;
                worksheet.Cells.Style.Font.Name = WorksheetFont;

                // Report heading
                worksheet.Cells[2, 1].Value = Helpers.GetMonthName(startTime.Month) + ", " + startTime.Year + " Attendance File";
                worksheet.Cells[2, 1].Style.Font.Bold = true;
                worksheet.Cells[2, 1].Style.Font.UnderLine = true;

                // Column headings
                worksheet.Cells[4, 1].Value = "School Division DAN";
                worksheet.Cells[4, 2].Value = "School DAN";
                worksheet.Cells[4, 3].Value = "Student Number";
                worksheet.Cells[4, 4].Value = "Birthdate";
                worksheet.Cells[4, 5].Value = "Active Date";
                worksheet.Cells[4, 6].Value = "Inactive Date";
                worksheet.Cells[4, 7].Value = "Grade";
                worksheet.Cells[4, 8].Value = "Possible Days";
                worksheet.Cells[4, 9].Value = "Absent Days";

                // Column headings border (like in the example file)
                worksheet.Cells[4, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[4, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[4, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[4, 4].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[4, 5].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[4, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[4, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[4, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[4, 9].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                // Data starts on row 5
                int dataRowNumber = 5;

                // Data
                foreach (School school in studentsBySchool.Keys)
                {
                    foreach (Student student in studentsBySchool[school])
                    {

                        decimal possibleDays = (decimal)student.Schedule.GetExpectedAttendanceBlocksFor(startTime, endTime, school) /
                                (decimal)student.Schedule.Track.DailyBlocksPerDay;

                        // Don't display students who would have zero possible periods
                        // Don't display students who are not registered with sask learning
                        if (
                            (possibleDays > 0) &&
                            (!string.IsNullOrEmpty(student.SaskLearningID))
                            )
                        {
                            decimal absentDays = (decimal)student.Attendance.Between(startTime, endTime).Absences.Count / (decimal)student.Schedule.Track.DailyBlocksPerDay;

                            // Deal with more secretary stupidity
                            if (absentDays > possibleDays)
                            {
                                absentDays = possibleDays;
                            }

                            StudentStatusEntry mostRecentStatus = student.Schedule.Statuses.GetMostRecentStatusForSchool(school);

                            string inDateText = string.Empty;
                            string outDateText = string.Empty;
                            if (mostRecentStatus != null)
                            {
                                inDateText = mostRecentStatus.InDate.ToShortDateString();
                                if (mostRecentStatus.OutDate != DateTime.MinValue)
                                {
                                    outDateText = mostRecentStatus.OutDate.ToShortDateString();
                                }
                            }

                            worksheet.Cells[dataRowNumber, 1].Value = divisionDAN;
                            worksheet.Cells[dataRowNumber, 2].Value = school.GovernmentID;
                            worksheet.Cells[dataRowNumber, 3].Value = student.SaskLearningID;
                            worksheet.Cells[dataRowNumber, 4].Value = student.DateOfBirth.ToShortDateString();
                            worksheet.Cells[dataRowNumber, 5].Value = inDateText;
                            worksheet.Cells[dataRowNumber, 6].Value = outDateText;
                            worksheet.Cells[dataRowNumber, 7].Value = student.GradeFormatted;
                            worksheet.Cells[dataRowNumber, 8].Value = possibleDays;
                            worksheet.Cells[dataRowNumber, 9].Value = absentDays;
                            dataRowNumber++;
                        }
                    }
                }

                // Set columns to autofit
                for (int col = 1; col <= 9; col++)
                {
                    worksheet.Column(col).AutoFit();
                }

                xlPackage.Save();
            }
            return returnMe;
        }

        /// <summary>
        /// Generate an XLSX document for PERIOD attendance students
        /// </summary>
        /// <param name="studentsBySchool">List of students</param>
        /// <param name="startTime">Start of the date range used for the report</param>
        /// <param name="endTime">End of the date range used for the report</param>
        /// <param name="divisionDAN">The division's government ID number</param>
        /// <returns></returns>
        public static MemoryStream GenerateXLSX_Period(Dictionary<School, List<Student>> studentsBySchool, DateTime startTime,
            DateTime endTime, string divisionDAN)
        {
            MemoryStream returnMe = new MemoryStream();
            using (ExcelPackage xlPackage = new ExcelPackage(returnMe))
            {
                xlPackage.Workbook.Worksheets.Add(WorksheetName);
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[WorksheetName];
                worksheet.Cells.Style.Font.Size = WorksheetFontSize;
                worksheet.Cells.Style.Font.Name = WorksheetFont;

                // Report heading
                worksheet.Cells[2, 1].Value = Helpers.GetMonthName(startTime.Month) + ", " + startTime.Year + " Attendance File";
                worksheet.Cells[2, 1].Style.Font.Bold = true;
                worksheet.Cells[2, 1].Style.Font.UnderLine = true;

                // Column headings
                worksheet.Cells[4, 1].Value = "School Division DAN";
                worksheet.Cells[4, 2].Value = "School DAN";
                worksheet.Cells[4, 3].Value = "Student Number";
                worksheet.Cells[4, 4].Value = "Birthdate";
                worksheet.Cells[4, 5].Value = "Active Date";
                worksheet.Cells[4, 6].Value = "Inactive Date";
                worksheet.Cells[4, 7].Value = "Grade";
                worksheet.Cells[4, 8].Value = "Class ID";
                worksheet.Cells[4, 9].Value = "Possible periods";
                worksheet.Cells[4, 10].Value = "Absent periods";

                // Column headings border (like in the example file)
                for (int col = 1; col <= 10; col++)
                {
                    worksheet.Cells[4, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                // Data starts on row 5
                int dataRowNumber = 5;

                // Data
                foreach (School school in studentsBySchool.Keys)
                {
                    foreach (Student student in studentsBySchool[school])
                    {
                        // Foreach class that this student is enrolled in at this time
                        foreach (StudentEnrolledClass sec in student.Schedule.EnrolledClassesOn(startTime))
                        {
                            // Don't display courses without government IDs, or classes which failed to load courses
                            if (sec.CourseInfo != null)
                            {
                                if (!string.IsNullOrEmpty(sec.CourseInfo.GovernmentCourseCode))
                                {
                                    // For period attendance, display the individual class in/out dates instead of the student's
                                    string inDateText = string.Empty;
                                    string outDateText = string.Empty;

                                    inDateText = sec.InDate.ToShortDateString();
                                    if (sec.OutDate != DateTime.MinValue)
                                    {
                                        if (sec.OutDate < endTime)
                                        {
                                            outDateText = sec.OutDate.ToShortDateString();
                                        }
                                    }

                                    int possiblePeriods = student.Schedule.GetExpectedAttendanceBlocksFor(startTime, endTime, sec.ClassInfo);

                                    // Don't display students who would have zero possible periods
                                    if (
                                        (possiblePeriods > 0) &&
                                        (!string.IsNullOrEmpty(student.SaskLearningID))
                                        )
                                    {
                                        // Get absences for just this class
                                        int absentPeriods = student.Attendance.Between(startTime, endTime).Absences.Where(c => c.ClassID == sec.ClassInfo.ID).ToList().Count;

                                        // Deal with more secretary stupidity
                                        if (absentPeriods > possiblePeriods)
                                        {
                                            absentPeriods = possiblePeriods;
                                        }

                                        string courseString = string.Empty;
                                        if (sec.ClassInfo.CourseInfo != null)
                                        {
                                            courseString = sec.ClassInfo.CourseInfo.GovernmentCourseCode;
                                        }

                                        worksheet.Cells[dataRowNumber, 1].Value = divisionDAN;
                                        worksheet.Cells[dataRowNumber, 2].Value = school.GovernmentID;
                                        worksheet.Cells[dataRowNumber, 3].Value = student.SaskLearningID;
                                        worksheet.Cells[dataRowNumber, 4].Value = student.DateOfBirth.ToShortDateString();
                                        worksheet.Cells[dataRowNumber, 5].Value = inDateText;
                                        worksheet.Cells[dataRowNumber, 6].Value = outDateText;
                                        worksheet.Cells[dataRowNumber, 7].Value = student.GradeFormatted;
                                        worksheet.Cells[dataRowNumber, 8].Value = courseString;
                                        worksheet.Cells[dataRowNumber, 9].Value = possiblePeriods;
                                        worksheet.Cells[dataRowNumber, 10].Value = absentPeriods;

                                        dataRowNumber++;
                                    }
                                }//if course has a gov ID
                            } // if course is not null
                        }// foreach studentenrolledclass
                    }// foreach student
                } // foreach school

                // Set columns to autofit
                for (int col = 1; col <= 10; col++)
                {
                    worksheet.Column(col).AutoFit();
                }

                xlPackage.Save();
            }
            return returnMe;
        }

    }
}
