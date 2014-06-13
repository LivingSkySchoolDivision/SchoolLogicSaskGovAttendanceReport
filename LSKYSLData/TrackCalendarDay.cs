using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class TrackCalendarDay
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int TrackID { get; set; }
        public int SchoolID { get; set; }
        public string SchoolDayNumberString { get; set; }
        public bool Available { get; set; }

        public int Day
        {
            get
            {
                return this.Date.Day;
            }
        }
        public int Year
        {
            get
            {
                return this.Date.Year;
            }
        }
        public int Month
        {
            get
            {
                return this.Date.Month;

            }
        }
        public int SchoolDayNumber
        {
            get
            {
                if (SchoolDayNumberString.ToLower() == "n")
                {
                    return -1;
                }

                return Helpers.ParseInt(SchoolDayNumberString);
            }
        }
        public bool IsWeekend
        {
            get
            {
                if ((this.Date.DayOfWeek == DayOfWeek.Saturday) || (this.Date.DayOfWeek == DayOfWeek.Sunday))
                {
                    return true;
                }
                return false;
            }
        }
        public bool IsInstructional
        {
            get
            {
                if ((this.SchoolDayNumberString.ToLower() == "n") || (string.IsNullOrEmpty(this.SchoolDayNumberString.Trim())))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public TrackCalendarDay(int id, int trackid, string daystring, bool available, DateTime date)
        {
            this.ID = id;
            this.TrackID = trackid;
            this.SchoolDayNumberString = daystring;
            this.Available = available;
            this.Date = date;
        }

        private static TrackCalendarDay DataReaderToSchoolCalendarDay(SqlDataReader dataReader)
        {
            TrackCalendarDay returnMe = new TrackCalendarDay(
                Helpers.ParseInt(dataReader["iCalendarID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iTrackID"].ToString().Trim()),
                dataReader["cDayNumber"].ToString().Trim(),
                Helpers.ParseBool(dataReader["lAvailable"].ToString().Trim()),
                Helpers.ParseDate(dataReader["dDate"].ToString().Trim())
                );

            return returnMe;
        }

        private static Dictionary<int, List<TrackCalendarDay>> _calendarDayCache; // By Track ID
        private static DateTime _calendarDayCacheLastUpdated;

        private static Dictionary<int, List<TrackCalendarDay>> GetCache(SqlConnection connection)
        {
            if (DateTime.Now.Subtract(_calendarDayCacheLastUpdated) > Helpers.CacheLifetime)
            {
                Helpers.DebugMsg("Refreshing calendar day cache");
                _calendarDayCache = new Dictionary<int, List<TrackCalendarDay>>();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT * FROM Calendar";
                sqlCommand.Connection.Open();
                SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        TrackCalendarDay newDay = DataReaderToSchoolCalendarDay(dbDataReader);
                        if (newDay != null)
                        {
                            if (!_calendarDayCache.ContainsKey(newDay.TrackID))
                            {
                                _calendarDayCache.Add(newDay.TrackID, new List<TrackCalendarDay>());
                            }
                            _calendarDayCache[newDay.TrackID].Add(newDay);
                        }
                    }
                }
                sqlCommand.Connection.Close();

                _calendarDayCacheLastUpdated = DateTime.Now;

            }

            return _calendarDayCache;
        }

        public static List<TrackCalendarDay> LoadCalendarDaysForTrack(SqlConnection connection, Track track)
        {
            if (GetCache(connection).ContainsKey(track.ID))
            {
                return GetCache(connection)[track.ID];
            }

            return new List<TrackCalendarDay>();
        }

    }
}
