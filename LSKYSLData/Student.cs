using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class Student
    {
        public int ID { get; set; }
        public string StudentNumber { get; set; }
        public string SaskLearningID { get; set; }
        public string Grade { get; set; }
        public string GradeFormatted
        {
            get
            {
                string returnMe = this.Grade;
                try
                {
                    int intVal = int.Parse(this.Grade);
                    returnMe = intVal.ToString();
                }
                catch
                {
                    if (this.Grade.ToLower() == "0k")
                    {
                        returnMe = "K";
                    }

                    if (this.Grade.ToLower() == "k")
                    {
                        returnMe = "K";
                    }

                    if (this.Grade.ToLower() == "pk")
                    {
                        returnMe = "PK";
                    }
                }

                return returnMe;
            }
        }
        public DateTime DateOfBirth { get; set; }
        public Track Track { get; set; }
        public School School { get; set; }
        public StudentAttendance Attendance { get; set; }
        public StudentSchedule Schedule { get; set; }

        private int SchoolID { get; set; }
        private int TrackId { get; set; }

        public Student(int id, string slnumber, int schoolID, int trackID, string saskLearningID, DateTime dateOfBirth, string grade)
        {
            this.ID = id;
            this.StudentNumber = slnumber;
            this.SchoolID = schoolID;
            this.TrackId = trackID;
            this.SaskLearningID = saskLearningID;
            this.DateOfBirth = dateOfBirth;
            this.Grade = grade;

            this.Attendance = new StudentAttendance();
            this.Schedule = new StudentSchedule();
        }

        private static Student DataReaderToStudent(SqlDataReader dataReader)
        {
            return new Student(
                Helpers.ParseInt(dataReader["iStudentID"].ToString()),
                dataReader["cStudentNumber"].ToString(),
                Helpers.ParseInt(dataReader["iSchoolID"].ToString()),
                Helpers.ParseInt(dataReader["iTrackID"].ToString()),
                dataReader["cGovernmentNumber"].ToString(),
                Helpers.ParseDate(dataReader["dbirthDate"].ToString()),
                dataReader["cGrade"].ToString()
                );
        }

        public static List<Student> LoadForSchool(SqlConnection connection, School school, DateTime enrolledFrom, DateTime enrolledTo)
        {
            List<Student> returnMe = new List<Student>();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "SELECT StudentStatus.iSchoolID, Student.iStudentID, Student.cStudentNumber, Student.dBirthdate, Student.cGovernmentNumber , Student.iTrackID, Grades.cName as cGrade FROM StudentStatus LEFT OUTER JOIN Student ON StudentStatus.iStudentID = Student.iStudentID LEFT OUTER JOIN Grades ON Student.iGradesID = Grades.iGradesID WHERE iTrackID != 0 AND StudentStatus.iSchoolID=@SCHOOLID AND (dOutDate = CONVERT(DATETIME, '1900-01-01 00:00:00', 102) OR (dOutDate>=@STARTTIME AND dOutDate<=@ENDTIME)) AND dInDate<@ENDTIME ORDER BY cStudentNumber ASC;";
            sqlCommand.Parameters.AddWithValue("STARTTIME", enrolledFrom);
            sqlCommand.Parameters.AddWithValue("ENDTIME", enrolledTo);
            sqlCommand.Parameters.AddWithValue("SCHOOLID", school.ID);

            sqlCommand.Connection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Student foundStudent = DataReaderToStudent(dataReader);
                    if (foundStudent != null)
                    {
                        returnMe.Add(foundStudent);
                    }
                }
            }
            sqlCommand.Connection.Close();

            foreach (Student student in returnMe)
            {
                // Set the student's school
                student.School = school;

                // Load the student's track
                student.Track = Track.LoadTrack(connection, student.TrackId);
            }

            return returnMe;
        }
    }
}
