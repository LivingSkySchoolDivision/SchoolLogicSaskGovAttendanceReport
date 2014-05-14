using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public class SchoolDistrict
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public SchoolDistrict(int id, string name)
        {
            this.Name = name;
            this.ID = id;
        }

        private static SchoolDistrict DataReaderToSchoolDistrict(SqlDataReader dataReader)
        {
            return new SchoolDistrict(Helpers.ParseInt(dataReader["iDistrictID"].ToString().Trim()), dataReader["cName"].ToString().Trim());
        }

        public static List<SchoolDistrict> LoadAll(SqlConnection connection)
        {
            List<SchoolDistrict> returnedDistricts = new List<SchoolDistrict>();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "SELECT * FROM District";
            sqlCommand.Connection.Open();
            SqlDataReader dbDataReader = sqlCommand.ExecuteReader();

            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                {
                    SchoolDistrict sd = DataReaderToSchoolDistrict(dbDataReader);
                    if (sd != null)
                    {
                        returnedDistricts.Add(sd);
                    }
                }
            }

            sqlCommand.Connection.Close();

            return returnedDistricts;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
