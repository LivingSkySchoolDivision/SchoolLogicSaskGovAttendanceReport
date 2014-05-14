using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class TrackCalendar
    {
        private List<TrackCalendarDay> Days { get; set; }
        public List<TrackCalendarDay> InstructionalDays
        {
            get
            {
                return this.Days.Where(c => c.IsInstructional == true).OrderBy(c => c.Date).ToList<TrackCalendarDay>();
            }
        }
        public List<TrackCalendarDay> NonInstructionalDays
        {
            get
            {
                return this.Days.Where(c => c.IsInstructional == false).OrderBy(c => c.Date).ToList<TrackCalendarDay>();
            }
        }
        public List<TrackCalendarDay> Holidays
        {
            get
            {
                return this.Days.Where(c => c.IsInstructional == false && c.IsWeekend == false).OrderBy(c => c.Date).ToList<TrackCalendarDay>();
            }
        }
        public TrackCalendarDay LastInstructionalDay
        {
            get
            {
                foreach (TrackCalendarDay day in this.InstructionalDays.OrderByDescending(c => c.Date))
                {
                    if (day.IsInstructional)
                    {
                        return day;
                    }
                }
                return null;

            }
        }
        public TrackCalendarDay FirstInstructionalDay
        {
            get
            {
                foreach (TrackCalendarDay day in this.InstructionalDays)
                {
                    if (day.IsInstructional)
                    {
                        return day;
                    }
                }
                return null;
            }
        }

        public TrackCalendar(SqlConnection connection, Track track)
        {
            this.Days = TrackCalendarDay.LoadCalendarDaysForTrack(connection, track);
        }

        public TrackCalendar(List<TrackCalendarDay> days)
        {
            this.Days = days;
        }

        public bool IsInstructional(DateTime thisDay)
        {
            TrackCalendarDay SelectedDay = GetSchoolCalendarDay(thisDay);
            if (SelectedDay != null)
            {
                if (SelectedDay.IsInstructional)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public int GetInstructionalDayCountAt(DateTime thisDay)
        {
            return GetInstructionalDayCountAt(thisDay.Year, thisDay.Month, thisDay.Day);
        }

        public int GetInstructionalDayCountAt(int year, int month)
        {
            return GetInstructionalDayCountAt(year, month, 0);
        }

        public int GetInstructionalDayCountAt(int year, int month, int Day)
        {
            DateTime ThisDay = new DateTime(year, month, Day);
            int DayCount = 0;
            foreach (TrackCalendarDay day in this.Days.OrderBy(c => c.Date).ToList<TrackCalendarDay>())
            {
                if (ThisDay >= day.Date)
                {
                    if (day.IsInstructional)
                    {
                        DayCount++;
                    }
                }
            }
            return DayCount;
        }

        public int GetInstructionalDayCountBetween(DateTime startDate, DateTime endDate)
        {
            int DayCount = 0;
            foreach (TrackCalendarDay day in this.Days)
            {
                if ((day.Date >= startDate) && (day.Date <= endDate))
                {
                    if (day.IsInstructional)
                    {
                        DayCount++;
                    }
                }
            }
            return DayCount;
        }

        public TrackCalendar Between(DateTime startDate, DateTime endDate)
        {
            return new TrackCalendar(this.Days.Where(c => c.Date >= startDate && c.Date <= endDate).ToList<TrackCalendarDay>());
        }

        public TrackCalendarDay GetSchoolCalendarDay(DateTime thisDay)
        {
            foreach (TrackCalendarDay day in this.Days)
            {
                if ((day.Year == thisDay.Year) && (day.Month == thisDay.Month) && (day.Day == thisDay.Day))
                {
                    return day;
                }
            }
            return null;
        }

        private TrackCalendarDay GetSchoolCalendarDay(int year, int month, int day)
        {
            foreach (TrackCalendarDay sd in this.Days)
            {
                if ((sd.Year == year) && (sd.Month == month) && (sd.Day == day))
                {
                    return sd;
                }
            }
            return null;
        }
    }
}
