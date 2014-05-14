using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class SchoolClass
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string Section { get; set; }
        public string Name { get; set; }
        public SchoolCourse CourseInfo { get; set; }
        public List<SchoolClassScheduleEntry> Schedule { get; set; }

        public SchoolClass(int id, int courseid, string section, string name)
        {
            this.ID = id;
            this.CourseID = courseid;
            this.Section = section;
            this.Name = name;
        }

        private static SchoolClass DataReaderToSchoolClass(SqlDataReader dataReader)
        {
            return new SchoolClass(
                Helpers.ParseInt(dataReader["iClassID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iCourseID"].ToString().Trim()),
                dataReader["cSection"].ToString().Trim(),
                dataReader["cName"].ToString().Trim()
                );
        }

        private static Dictionary<int, SchoolClass> _classCache;
        private static DateTime _classCacheLastUpdated;

        private static Dictionary<int, SchoolClass> GetCache(SqlConnection connection)
        {
            if (DateTime.Now.Subtract(_classCacheLastUpdated) > Helpers.CacheLifetime)
            {
                Helpers.DebugMsg("Refreshing class cache");
                _classCache = new Dictionary<int, SchoolClass>();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT iClassID, cName, iCourseID, cSection FROM Class;";
                sqlCommand.Connection.Open();
                SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        SchoolClass newClass = DataReaderToSchoolClass(dbDataReader);
                        if (newClass != null)
                        {
                            _classCache.Add(newClass.ID, newClass);
                        }
                    }
                }

                sqlCommand.Connection.Close();

                _classCacheLastUpdated = DateTime.Now;

                // Load supplimental information for classes
                foreach (int classID in _classCache.Keys)
                {
                    // Load course information
                    _classCache[classID].CourseInfo = SchoolCourse.LoadCourse(connection, _classCache[classID].CourseID);

                    // Load schedule
                    _classCache[classID].Schedule = SchoolClassScheduleEntry.LoadScheduleAsList(connection,
                        _classCache[classID]);
                }
            }

            return _classCache;
        }

        public static SchoolClass LoadClass(SqlConnection connection, int classId)
        {
            if (GetCache(connection).ContainsKey(classId))
            {
                return GetCache(connection)[classId];
            }

            return null;
        }

    }
}
