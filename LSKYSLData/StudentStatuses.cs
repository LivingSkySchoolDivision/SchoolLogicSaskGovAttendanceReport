using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class StudentStatuses
    {
        public List<StudentStatusEntry> AllStatuses { get; set; }
        public StudentStatuses ActiveStatuses
        {
            get
            {
                return new StudentStatuses(this.AllStatuses.Where(c => c.IsActive == true).ToList());
            }
        }
        public StudentStatuses InActiveStatuses
        {
            get
            {
                return new StudentStatuses(this.AllStatuses.Where(c => c.IsActive == false).ToList());
            }
        }

        public StudentStatuses()
        {
            this.AllStatuses = new List<StudentStatusEntry>();
        }

        public StudentStatuses(List<StudentStatusEntry> statusList)
        {
            this.AllStatuses = statusList ?? new List<StudentStatusEntry>();
        }

        public StudentStatuses(SqlConnection connection, Student student)
        {
            this.AllStatuses = StudentStatusEntry.LoadStatusesForThisStudent(connection, student);
        }

        public StudentStatuses ForSchool(School school)
        {
            return new StudentStatuses(this.AllStatuses.Where(ss => ss.SchoolID == school.ID).ToList());
        }

        public StudentStatusEntry GetMostRecentStatusForSchool(School school)
        {
            return this.ForSchool(school).AllStatuses.OrderByDescending(c => c.InDate).ToList().FirstOrDefault();
        }

        public StudentStatusEntry WithID(int statusID)
        {
            foreach (StudentStatusEntry sse in AllStatuses)
            {
                if (sse.ID == statusID)
                {
                    return sse;
                }
            }
            return null;
        }
    }
}
