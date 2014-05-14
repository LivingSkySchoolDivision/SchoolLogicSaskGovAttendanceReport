using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class StudentAttendance
    {
        private readonly List<Absence> _absences;
        public List<Absence> Absences
        {
            get
            {
                return this._absences.Where(c => c.IsLate == false).OrderBy(c => c.Date).ToList<Absence>();
            }
        }
        public List<Absence> Lates
        {
            get
            {
                return this._absences.Where(c => c.IsLate == true).OrderBy(c => c.Date).ToList<Absence>();
            }
        }
        public List<Absence> Excused
        {
            get
            {
                return this._absences.Where(c => c.IsLate == false && c.IsExcused == true).OrderBy(c => c.Date).ToList<Absence>();
            }
        }
        public List<Absence> Unexcused
        {
            get
            {
                return this._absences.Where(c => c.IsLate == false && c.IsExcused == false).OrderBy(c => c.Date).ToList<Absence>();
            }
        }
        public List<Absence> AllAttendanceEntries
        {
            get
            {
                return this._absences;
            }
        }
        public int TotalLateMinutes
        {
            get
            {
                return this.Lates.Sum(abs => abs.LateMinutes);
            }
        }

        public override string ToString()
        {
            return "Attenance { Total: " + this._absences.Count + ", Excused: " + this.Excused.Count + ", Unexcused: " + this.Unexcused.Count + ", Lates: " + this.Lates.Count + " }";
        }

        public StudentAttendance(SqlConnection connection, Student student, School school, DateTime from, DateTime to)
        {
            this._absences = Absence.LoadForStudent(connection, student, school, from, to);
        }

        public StudentAttendance(List<Absence> absences)
        {
            this._absences = absences;
        }

        public StudentAttendance()
        {
            this._absences = new List<Absence>();
        }

        public StudentAttendance Between(DateTime StartDate, DateTime EndDate)
        {
            return new StudentAttendance(this._absences.Where(c => c.Date >= StartDate && c.Date <= EndDate).OrderBy(c => c.Date).ToList<Absence>());
        }

        public StudentAttendance ForClass(int classID)
        {
            return new StudentAttendance(this._absences.Where(c => c.ClassID == classID).ToList());
        }

        public StudentAttendance ForClass(SchoolClass sClass)
        {
            return ForClass(sClass.ID);
        }

    }
}
