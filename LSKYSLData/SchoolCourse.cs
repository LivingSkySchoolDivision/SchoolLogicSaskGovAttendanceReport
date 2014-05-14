using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class SchoolCourse
    {
        public int ID { get; set; }
        public int GovernmentCourseID { get; set; }
        public string GovernmentCourseCode { get; set; }
        public string Name { get; set; }

        public SchoolCourse(int id, int govID, string courseCode, string name)
        {
            this.ID = id;
            this.GovernmentCourseID = govID;
            this.GovernmentCourseCode = courseCode;
            this.Name = name;
        }

        private static SchoolCourse DataReaderToCourse(SqlDataReader dataReader)
        {
            return new SchoolCourse(
                Helpers.ParseInt(dataReader["iCourseID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iGovCourseID"].ToString().Trim()),
                dataReader["cGovernmentCode"].ToString().Trim(),
                dataReader["cName"].ToString().Trim()
                );
        }

        private static Dictionary<int, SchoolCourse> _courseCache;
        private static DateTime _courseCacheLastUpdated;
        private static Dictionary<int, SchoolCourse> GetCache(SqlConnection connection)
        {
            if (DateTime.Now.Subtract(_courseCacheLastUpdated) > Helpers.CacheLifetime)
            {
                Helpers.DebugMsg("Refreshing course cache");
                _courseCache = new Dictionary<int, SchoolCourse>();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT iCourseID, cName, cCourseCode, iGovCourseID, cGovernmentCode FROM Course;";
                sqlCommand.Connection.Open();
                SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        SchoolCourse newCourse = DataReaderToCourse(dbDataReader);
                        if (newCourse != null)
                        {
                            _courseCache.Add(newCourse.ID, newCourse);
                        }
                    }
                }

                sqlCommand.Connection.Close();

                _courseCacheLastUpdated = DateTime.Now;
            }

            return _courseCache;
        }

        public static SchoolCourse LoadCourse(SqlConnection connection, int courseID)
        {
            if (GetCache(connection).ContainsKey(courseID))
            {
                return GetCache(connection)[courseID];
            }

            return null;
        }


    }
}
