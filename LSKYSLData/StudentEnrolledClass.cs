using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class StudentEnrolledClass
    {
        public int ID { get; set; }
        public int ClassID { get; set; }
        public int StudentID { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }

        public SchoolClass ClassInfo { get; set; }
        public SchoolCourse CourseInfo { get; set; }

        public StudentEnrolledClass(int id, int classId, int studentID, DateTime inDate, DateTime outDate)
        {
            this.ID = id;
            this.ClassID = classId;
            this.StudentID = studentID;
            this.InDate = inDate;
            this.OutDate = outDate;
        }

        private static StudentEnrolledClass DataReaderToStudentEnrolledClass(SqlDataReader dataReader)
        {
            return new StudentEnrolledClass(
                Helpers.ParseInt(dataReader["iEnrollmentID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iClassID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iStudentID"].ToString().Trim()),
                Helpers.ParseDate(dataReader["dInDate"].ToString().Trim()),
                Helpers.ParseDate(dataReader["dOutDate"].ToString().Trim())
                );
        }

        private static Dictionary<int, List<StudentEnrolledClass>> _enrollmentCache; // Int is student ID
        private static DateTime _enrollmentCacheLastUpdated;
        private static Dictionary<int, List<StudentEnrolledClass>> GetCache(SqlConnection connection)
        {
            if (DateTime.Now.Subtract(_enrollmentCacheLastUpdated) > Helpers.CacheLifetime)
            {
                Helpers.DebugMsg("Refreshing enrollment cache");

                _enrollmentCache = new Dictionary<int, List<StudentEnrolledClass>>();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT iEnrollmentID, iStudentID, iClassID, dInDate, dOutDate FROM Enrollment";
                sqlCommand.Connection.Open();
                SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        StudentEnrolledClass newEnrollment = DataReaderToStudentEnrolledClass(dbDataReader);
                        if (newEnrollment != null)
                        {
                            if (!_enrollmentCache.ContainsKey(newEnrollment.StudentID))
                            {
                                _enrollmentCache.Add(newEnrollment.StudentID, new List<StudentEnrolledClass>());
                            }
                            _enrollmentCache[newEnrollment.StudentID].Add(newEnrollment);
                        }
                    }
                }

                sqlCommand.Connection.Close();

                // Load class and course info
                foreach (int studentID in _enrollmentCache.Keys)
                {
                    foreach (StudentEnrolledClass sec in _enrollmentCache[studentID])
                    {
                        sec.ClassInfo = SchoolClass.LoadClass(connection, sec.ClassID);
                        if (sec.ClassInfo != null)
                        {
                            sec.CourseInfo = SchoolCourse.LoadCourse(connection, sec.ClassInfo.CourseID);
                        }
                    }
                }

                _enrollmentCacheLastUpdated = DateTime.Now;
            }

            return _enrollmentCache;
        }

        public static List<StudentEnrolledClass> LoadAllFor(SqlConnection connection, Student student)
        {
            if (GetCache(connection).ContainsKey(student.ID))
            {
                return GetCache(connection)[student.ID];
            }

            return new List<StudentEnrolledClass>();
        }
    }
}
