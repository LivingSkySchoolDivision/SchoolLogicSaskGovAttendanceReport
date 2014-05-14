using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class SchoolClassScheduleEntry
    {
        public int ID { get; set; }
        public int ClassID { get; set; }
        public int Block { get; set; }
        public int Day { get; set; }
        public int SchoolID { get; set; }

        public SchoolClassScheduleEntry(int id, int classID, int block, int day, int schoolID)
        {
            this.ID = id;
            this.Block = block;
            this.Day = day;
            this.SchoolID = schoolID;
            this.ClassID = classID;
        }

        private static SchoolClassScheduleEntry DataReaderToSCSE(SqlDataReader dataReader)
        {
            return new SchoolClassScheduleEntry(
                Helpers.ParseInt(dataReader["iClassScheduleID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iClassID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iBlockNumber"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iDayNumber"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iSchoolID"].ToString().Trim())
                );
        }

        private static Dictionary<int, Dictionary<int, Dictionary<int, SchoolClassScheduleEntry>>> _scheduleClassCache; // ClassID, Day, Block
        private static DateTime _scheduleCacheLastUpdated;
        private static Dictionary<int, Dictionary<int, Dictionary<int, SchoolClassScheduleEntry>>> GetCache(
            SqlConnection connection)
        {
            if (DateTime.Now.Subtract(_scheduleCacheLastUpdated) > Helpers.CacheLifetime)
            {
                _scheduleClassCache = new Dictionary<int, Dictionary<int, Dictionary<int, SchoolClassScheduleEntry>>>();
                Helpers.DebugMsg("Refreshing class schedule cache");

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT ClassSchedule.iClassScheduleID, ClassSchedule.iBlockNumber, ClassSchedule.iDayNumber, ClassSchedule.iSchoolID, ClassResource.iClassID FROM ClassSchedule LEFT OUTER JOIN ClassResource ON ClassSchedule.iClassResourceID = ClassResource.iClassResourceID";
                sqlCommand.Connection.Open();
                SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        SchoolClassScheduleEntry newEntry = DataReaderToSCSE(dbDataReader);
                        if (newEntry != null)
                        {
                            if (!_scheduleClassCache.ContainsKey(newEntry.ClassID))
                            {
                                _scheduleClassCache.Add(newEntry.ClassID, new Dictionary<int, Dictionary<int, SchoolClassScheduleEntry>>());
                            }

                            if (!_scheduleClassCache[newEntry.ClassID].ContainsKey(newEntry.Day))
                            {
                                _scheduleClassCache[newEntry.ClassID].Add(newEntry.Day, new Dictionary<int, SchoolClassScheduleEntry>());
                            }

                            if (!_scheduleClassCache[newEntry.ClassID][newEntry.Day].ContainsKey(newEntry.Block))
                            {
                                _scheduleClassCache[newEntry.ClassID][newEntry.Day].Add(newEntry.Block, newEntry);
                            }
                            else
                            {
                                _scheduleClassCache[newEntry.ClassID][newEntry.Day][newEntry.Block] = newEntry;
                            }

                        }
                    }
                }

                sqlCommand.Connection.Close();

                _scheduleCacheLastUpdated = DateTime.Now;
            }

            return _scheduleClassCache;
        }


        public static List<SchoolClassScheduleEntry> LoadScheduleAsList(SqlConnection connection, SchoolClass sClass)
        {
            if (GetCache(connection).ContainsKey(sClass.ID))
            {
                List<SchoolClassScheduleEntry> returnMe = new List<SchoolClassScheduleEntry>();
                returnMe.AddRange(from dayNum in GetCache(connection)[sClass.ID].Keys from blockNum in GetCache(connection)[sClass.ID][dayNum].Keys select GetCache(connection)[sClass.ID][dayNum][blockNum]);
                return returnMe;
            }

            return new List<SchoolClassScheduleEntry>();
        }


    }
}
