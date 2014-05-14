using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class Absence
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public bool IsExcused { get; set; }
        public int LateMinutes { get; set; }
        public int ClassID { get; set; }
        public int StudentID { get; set; }
        public int SchoolID { get; set; }
        public bool IsLate
        {
            get
            {
                return this.LateMinutes > 0;
            }
        }

        public Absence(int id, int schoolID, DateTime date, int studentID, bool excused, int minutes, int classid)
        {
            this.ID = id;
            this.StudentID = studentID;
            this.Date = date;
            this.IsExcused = excused;
            this.LateMinutes = minutes;
            this.ClassID = classid;
            this.SchoolID = schoolID;
        }

        private static Absence DataReaderToAbsence(SqlDataReader dataReader)
        {
            return new Absence(
                Helpers.ParseInt(dataReader["iAttendanceID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iSchoolID"].ToString().Trim()),
                Helpers.ParseDate(dataReader["dDate"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iStudentID"].ToString().Trim()),
                Helpers.ParseBool(dataReader["lExcusable"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iMinutes"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iClassID"].ToString().Trim())
                );
        }

        // Cache attendance - we know we are loading attendance for all students so we don't have to be as picky about what to cache
        private static Dictionary<int, Dictionary<int, List<Absence>>> _absenceCache; // SchoolID, then StudentID, then list of absences
        private static DateTime _absenceCacheLastUpdated;
        private static DateTime _lastRequestDateRangeFrom;
        private static DateTime _lastRequestDateRangeTo;
        private static Dictionary<int, Dictionary<int, List<Absence>>> GetCache(SqlConnection connection, DateTime rangeFrom, DateTime rangeTo)
        {
            if (
                (DateTime.Now.Subtract(_absenceCacheLastUpdated) > Helpers.CacheLifetime) ||
                (_lastRequestDateRangeFrom != rangeFrom) ||
                (_lastRequestDateRangeTo != rangeTo)
                )
            {
                Helpers.DebugMsg("Refreshing absence cache");
                _absenceCache = new Dictionary<int, Dictionary<int, List<Absence>>>();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT Attendance.iAttendanceID, Attendance.dDate, Attendance.iStudentID, AttendanceReasons.lExcusable, Attendance.iMinutes, Attendance.iClassID, Attendance.iSchoolID FROM Attendance LEFT OUTER JOIN AttendanceReasons ON Attendance.iAttendanceReasonsID = AttendanceReasons.iAttendanceReasonsID WHERE dDate>=@STARTDATE AND dDate<=@ENDDATE ORDER BY dDate ASC";
                sqlCommand.Parameters.AddWithValue("STARTDATE", rangeFrom);
                sqlCommand.Parameters.AddWithValue("ENDDATE", rangeTo);
                sqlCommand.Connection.Open();
                SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        Absence newAbsence = DataReaderToAbsence(dbDataReader);
                        if (newAbsence != null)
                        {
                            if (!_absenceCache.ContainsKey(newAbsence.SchoolID))
                            {
                                _absenceCache.Add(newAbsence.SchoolID, new Dictionary<int, List<Absence>>());
                            }

                            if (!_absenceCache[newAbsence.SchoolID].ContainsKey(newAbsence.StudentID))
                            {
                                _absenceCache[newAbsence.SchoolID].Add(newAbsence.StudentID, new List<Absence>());
                            }

                            _absenceCache[newAbsence.SchoolID][newAbsence.StudentID].Add(newAbsence);
                        }
                    }
                }

                sqlCommand.Connection.Close();

                _absenceCacheLastUpdated = DateTime.Now;
                _lastRequestDateRangeFrom = rangeFrom;
                _lastRequestDateRangeTo = rangeTo;
            }

            return _absenceCache;
        }


        public static List<Absence> LoadForStudent(SqlConnection connection, Student student, School school, DateTime from, DateTime to)
        {
            if (GetCache(connection, from, to).ContainsKey(school.ID))
            {
                if (GetCache(connection, from, to)[school.ID].ContainsKey(student.ID))
                {
                    return GetCache(connection, from, to)[school.ID][student.ID];
                }
            }

            return new List<Absence>();
        }
    }
}
