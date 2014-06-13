using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class TrackCalendarOverride
    {
        // In this utility, I only actually care about the number of these that exist on a given day, and not their details

        public int ID { get; set; }
        public int TrackID { get; set; }
        public DateTime Date { get; set; }
        public int BlockNumber { get; set; }

        public TrackCalendarOverride(int id, int trackID, int blockNum, DateTime date)
        {
            this.TrackID = trackID;
            this.ID = id;
            this.BlockNumber = blockNum;
            this.Date = date;
        }

        public override string ToString()
        {
            return "TrackCalendarOverride { id: " + this.ID + ", block: " + this.BlockNumber + "date: " +
                   this.Date.ToShortDateString() + "}";
        }

        private static TrackCalendarOverride DataReaderToCalendarDayOverride(SqlDataReader dataReader)
        {
            return new TrackCalendarOverride(
                Helpers.ParseInt(dataReader["iCalendarDetailsID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iTrackID"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iBlockNumber"].ToString().Trim()),
                Helpers.ParseDate(dataReader["dDate"].ToString().Trim())
                );
        }

        private static Dictionary<int, List<TrackCalendarOverride>> _overrideCache; // by Track ID
        private static DateTime _cacheLastUpdated;

        private static Dictionary<int, List<TrackCalendarOverride>> GetCache(SqlConnection connection)
        {
            if (DateTime.Now.Subtract(_cacheLastUpdated) > Helpers.CacheLifetime)
            {
                Helpers.DebugMsg("Refreshing calendar override cache");
                _overrideCache = new Dictionary<int, List<TrackCalendarOverride>>();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT CalendarDetails.iCalendarDetailsID, CalendarDetails.iBlockNumber, CalendarDetails.mComment, Calendar.iTrackID, Calendar.dDate, Calendar.cDayNumber FROM CalendarDetails LEFT OUTER JOIN Calendar ON CalendarDetails.iCalendarID = Calendar.iCalendarID";
                sqlCommand.Connection.Open();
                SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        TrackCalendarOverride newOverride = DataReaderToCalendarDayOverride(dbDataReader);
                        if (newOverride != null)
                        {
                            if (!_overrideCache.ContainsKey(newOverride.TrackID))
                            {
                                _overrideCache.Add(newOverride.TrackID, new List<TrackCalendarOverride>());
                            }
                            _overrideCache[newOverride.TrackID].Add(newOverride);
                        }
                    }
                }
                sqlCommand.Connection.Close();

                _cacheLastUpdated = DateTime.Now;
            }
            return _overrideCache;
        }

        public static List<TrackCalendarOverride> Load(SqlConnection connection, Track track)
        {
            return GetCache(connection).ContainsKey(track.ID) ? GetCache(connection)[track.ID] : new List<TrackCalendarOverride>();
        }


    }
}
