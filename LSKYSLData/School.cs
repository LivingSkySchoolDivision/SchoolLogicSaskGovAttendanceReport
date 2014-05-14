using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class School
    {
        public int ID { get; set; }
        public string GovernmentID { get; set; }
        public string Name { get; set; }

        public School(int id, string govID, string name)
        {
            this.ID = id;
            this.GovernmentID = govID;
            this.Name = name;
        }

        private static School DataReaderToSchool(SqlDataReader dbDataReader)
        {
            return new School(
                Helpers.ParseInt(dbDataReader["iSchoolID"].ToString()),
                dbDataReader["cCode"].ToString(),
                dbDataReader["cName"].ToString()
                );
        }

        public static List<School> LoadAll(SqlConnection connection, SchoolDistrict district)
        {
            List<School> returnedSchools = new List<School>();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "SELECT * FROM School WHERE iDistrictID=@DISTRICT;";
            sqlCommand.Parameters.AddWithValue("DISTRICT", district.ID);
            sqlCommand.Connection.Open();
            SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                {
                    School newSchool = DataReaderToSchool(dbDataReader);
                    if (newSchool != null)
                    {
                        returnedSchools.Add(DataReaderToSchool(dbDataReader));
                    }
                }
            }

            sqlCommand.Connection.Close();

            return returnedSchools.OrderBy(c => c.Name).ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
