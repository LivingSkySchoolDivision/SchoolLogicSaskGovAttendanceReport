using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class Track
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDailyAttendance { get; set; }
        public int DailyBlocksPerDay { get; set; }
        public TrackCalendar Calendar { get; set; }

        public Track(int id, string name, bool isdaily, int dailyblocksperday)
        {
            this.ID = id;
            this.Name = name;
            this.IsDailyAttendance = isdaily;
            this.DailyBlocksPerDay = dailyblocksperday;
        }

        private static Track DataReaderToTrack(SqlDataReader dataReader)
        {
            return new Track(
                Helpers.ParseInt(dataReader["iTrackID"].ToString().Trim()),
                dataReader["cName"].ToString().Trim(),
                Helpers.ParseBool(dataReader["lDaily"].ToString().Trim()),
                Helpers.ParseInt(dataReader["iDailyBlocksPerDay"].ToString().Trim())
                );
        }

        private static Dictionary<int, Track> _trackCache;
        private static DateTime _trackCacheLastUpdate;
        private static Dictionary<int, Track> GetCache(SqlConnection connection)
        {
            if (_trackCache == null)
            {
                _trackCacheLastUpdate = DateTime.MinValue;
            }

            if (DateTime.Now.Subtract(_trackCacheLastUpdate) > Helpers.CacheLifetime)
            {
                Helpers.DebugMsg("Refreshing track cache");
                _trackCache = new Dictionary<int, Track>();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT * FROM Track;";
                sqlCommand.Connection.Open();
                SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        Track newTrack = DataReaderToTrack(dbDataReader);
                        if (newTrack != null)
                        {
                            _trackCache.Add(newTrack.ID, newTrack);
                        }
                    }
                }

                sqlCommand.Connection.Close();

                // Load supplimental information for tracks
                foreach (int trackID in _trackCache.Keys)
                {
                    _trackCache[trackID].Calendar = new TrackCalendar(connection, _trackCache[trackID]);
                }

                _trackCacheLastUpdate = DateTime.Now;
            }

            return _trackCache;
        }

        public static Track LoadTrack(SqlConnection connection, int trackID)
        {
            if (GetCache(connection).ContainsKey(trackID))
            {
                return GetCache(connection)[trackID];
            }
            else
            {
                return new Track(0, "Invalid track", true, 0);
            }
        }
    }
}
