using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class StudentSchedule
    {
        public Track Track { get; set; }
        public StudentStatuses Statuses { get; set; }
        public List<StudentEnrolledClass> AllEnrolledClasses { get; set; }

        public StudentSchedule(SqlConnection connection, Student student)
        {
            this.Track = student.Track;
            this.Statuses = new StudentStatuses(connection, student);
            this.AllEnrolledClasses = StudentEnrolledClass.LoadAllFor(connection, student);
        }

        public StudentSchedule()
        {
        }

        public List<StudentEnrolledClass> EnrolledClassesOn(DateTime thisDate)
        {
            return AllEnrolledClasses.Where(c => c.InDate <= thisDate && (c.OutDate >= thisDate || c.OutDate == DateTime.MinValue)).ToList();
        }

        public int GetExpectedAttendanceBlocksFor(DateTime thisDay, School school)
        {
            // See if the track is daily attendance and return the number of daily attendance blocks
            if (this.Track.IsDailyAttendance)
            {
                int expectedBlocks = 0;

                if (this.Track.Calendar.IsInstructional(thisDay))
                {
                    StudentStatusEntry currentStatus = Statuses.GetMostRecentStatusForSchool(school);
                    if (currentStatus != null)
                    {
                        if (currentStatus.OutDate != DateTime.MinValue)
                        {
                            if (currentStatus.OutDate > thisDay)
                            {
                                // The student has an outdate, but it's after the given date
                                expectedBlocks += this.Track.DailyBlocksPerDay;
                            }
                        }
                        else
                        {
                            // The student does not have an outdate
                            expectedBlocks += this.Track.DailyBlocksPerDay;
                        }

                        // Check for any calendar overrides
                        expectedBlocks -= this.Track.Calendar.GetOverridesOn(thisDay).Count;

                    }
                }

                return expectedBlocks;
            }
            else
            {
                return GetSchedule(thisDay).Count;
            }
        }

        public int GetExpectedAttendanceBlocksFor(DateTime fromThisDay, DateTime toThisDay, School school)
        {
            return Helpers.GetEachDayBetween(fromThisDay, toThisDay).Sum(day => GetExpectedAttendanceBlocksFor(day, school));
        }

        public int GetExpectedAttendanceBlocksFor(DateTime fromThisDay, DateTime toThisDay, SchoolClass thisClass)
        {
            int classCount = 0;
            foreach (DateTime day in Helpers.GetEachDayBetween(fromThisDay, toThisDay))
            {
                Dictionary<int, List<StudentEnrolledClass>> timeTableToday = GetSchedule(day);
                foreach (int block in timeTableToday.Keys)
                {
                    foreach (StudentEnrolledClass sec in timeTableToday[block])
                    {
                        if (sec.ClassInfo.ID == thisClass.ID)
                        {
                            classCount++;
                        }
                    }
                }
            }

            return classCount;
        }

        public Dictionary<int, List<StudentEnrolledClass>> GetSchedule(DateTime thisDay)
        {
            SortedDictionary<int, List<StudentEnrolledClass>> classesByPeriod = new SortedDictionary<int, List<StudentEnrolledClass>>();

            // Find out what school day the calendar day would be
            TrackCalendarDay scd = Track.Calendar.GetSchoolCalendarDay(thisDay);

            int dayNumber = -1;

            if (scd != null)
            {
                dayNumber = scd.SchoolDayNumber;
            }

            // If the day number is invalid (for example if it is a weekend), don't bother trying to create a schedule.
            if (dayNumber <= 0) return new Dictionary<int, List<StudentEnrolledClass>>(classesByPeriod);

            // Get which classes the student would be enrolled in at this time
            List<StudentEnrolledClass> enrolledClassesAtThisTime = this.EnrolledClassesOn(thisDay);

            // Find any classes scheduled for the given school day
            foreach (StudentEnrolledClass sec in enrolledClassesAtThisTime)
            {
                foreach (SchoolClassScheduleEntry cse in sec.ClassInfo.Schedule.Where(cse => cse.Day == dayNumber))
                {
                    if (!classesByPeriod.ContainsKey(cse.Block))
                    {
                        classesByPeriod.Add(cse.Block, new List<StudentEnrolledClass>());
                    }
                    classesByPeriod[cse.Block].Add(sec);
                }
            }

            return new Dictionary<int, List<StudentEnrolledClass>>(classesByPeriod);
        }


    }
}
