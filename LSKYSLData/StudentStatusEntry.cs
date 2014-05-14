using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class StudentStatusEntry
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int SchoolID { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public bool IsActive
        {
            get
            {
                return this.OutDate != DateTime.MinValue;
            }
        }

        public StudentStatusEntry(int id, int studentID, int schoolID, DateTime inDate, DateTime outDate)
        {
            this.ID = id;
            this.SchoolID = schoolID;
            this.InDate = inDate;
            this.OutDate = outDate;
            this.StudentID = studentID;
        }

        private static StudentStatusEntry DataReaderToStudentStatus(SqlDataReader dataReader)
        {
            return new StudentStatusEntry(
                Helpers.ParseInt(dataReader["iStudentStatusID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iStudentID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iSchoolID"].ToString().Trim()),
                Helpers.ParseDate(dataReader["dInDate"].ToString().Trim()),
                Helpers.ParseDate(dataReader["dOutDate"].ToString().Trim())
                );
        }

        private static Dictionary<int, List<StudentStatusEntry>> _statusCache;
        private static DateTime _cacheLastUpdate;
        private static Dictionary<int, List<StudentStatusEntry>> GetCache(SqlConnection connection)
        {
            if (DateTime.Now.Subtract(_cacheLastUpdate) > Helpers.CacheLifetime)
            {
                Helpers.DebugMsg("Refreshing status entry cache");
                _statusCache = new Dictionary<int, List<StudentStatusEntry>>();

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "SELECT * FROM StudentStatus";
                    sqlCommand.Connection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            StudentStatusEntry newStatus = DataReaderToStudentStatus(dataReader);
                            if (newStatus != null)
                            {
                                if (!_statusCache.ContainsKey(newStatus.StudentID))
                                {
                                    _statusCache.Add(newStatus.StudentID, new List<StudentStatusEntry>());
                                }
                                _statusCache[newStatus.StudentID].Add(newStatus);
                            }
                        }
                    }
                    sqlCommand.Connection.Close();
                }
                _cacheLastUpdate = DateTime.Now;
            }

            return _statusCache;
        }

        public static List<StudentStatusEntry> LoadStatusesForThisStudent(SqlConnection connection, Student student)
        {
            return GetCache(connection).ContainsKey(student.ID) ? GetCache(connection)[student.ID] : new List<StudentStatusEntry>();
        }
    }
}
