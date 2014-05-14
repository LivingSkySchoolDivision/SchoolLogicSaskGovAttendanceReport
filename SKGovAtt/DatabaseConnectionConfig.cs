using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using LSKYSLData;

namespace SKGovAtt
{
    public partial class DatabaseConnectionConfig : Form
    {
        public DatabaseConnectionConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parses the connection string from the user, removing characters that might break things
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string ParseConnectionString(string input)
        {
            return input.Replace("\n", "");
        }

        private string BuildConnectionString(string serverName, string username, string password, string dbName)
        {
            return "data source=" + serverName + ";initial catalog=" + dbName + ";user id=" + username + ";password=" + password + ";Trusted_Connection=false";
        }

        private void DatabaseConnectionConfig_Shown(object sender, EventArgs e)
        {
            txtConnectionString.Text = AppConfiguration.GetConnectionString();

            txtDatabaseName.Text = "SchoolLogicDB";
            txtPassword.Text = "password";
            txtUsername.Text = "readonly_username";
            txtServerName.Text = "sql.yourdomain";
            UpdateStatusbar("");
        }

        private void btnCreateConnectionString_Click(object sender, EventArgs e)
        {
            txtConnectionString.Text = BuildConnectionString(txtServerName.Text, txtUsername.Text, txtPassword.Text, txtDatabaseName.Text);
        }

        private void UpdateStatusbar(string message, Color color)
        {
            lblTestStatus.Text = message;
            lblTestStatus.ForeColor = color;
            lblTestStatus.Refresh();
        }

        private void UpdateStatusbar(string message)
        {
            UpdateStatusbar(message, Color.Black);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            UpdateStatusbar("Attempting to connect...");

            string connectionString = ParseConnectionString(txtConnectionString.Text);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    List<SchoolDistrict> AllDistricts = SchoolDistrict.LoadAll(connection);
                }
                UpdateStatusbar("Success!", Color.Green);
            } catch(Exception ex)
            {
                UpdateStatusbar("Failed: " + ex.Message, Color.DarkRed);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.connectionstrings.com/sql-server/");
            Process.Start(sInfo);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppConfiguration.SetConnectionString(txtConnectionString.Text);
            this.Close();
        }


    }
}
